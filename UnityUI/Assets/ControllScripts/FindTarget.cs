using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindTarget : MonoBehaviour {

    public GameObject target;
    public GameObject character;
    public GameObject text,text2,text3,text4;


    private CharacterController chaCon;
    private Animator ani;

    private bool m_wantToEat;
    private bool m_foodposition;
    private float m_hunger;
	// Use this for initialization
	void Start () {
        character = this.gameObject;
        ani = this.transform.GetComponent<Animator>();
        ani.SetBool("foodPosition", false);
        chaCon = this.transform.GetComponent<CharacterController>();

        m_wantToEat = false;
        m_foodposition = false;
        m_hunger = 15;
	}
	
	// Update is called once per frame
	void Update () {
        if (m_hunger <= 10.0f) m_wantToEat = true;

        if (SceneController.foodOn == true && m_wantToEat)
        {
            text.GetComponent<TextMesh>().text = "Found";
            character.transform.LookAt(target.transform);
            if (ani.GetBool("foodPosition")==false)
            chaCon.Move(this.transform.forward * 70.0f * Time.deltaTime);
            ani.SetBool("foodTargetOn", true);
        }
        else if (SceneController.foodOn == false && m_wantToEat)
        {
            text.GetComponent<TextMesh>().text = "Hungry but food is offline";
            ani.SetBool("foodTargetOn", false);
        }
        else if (!m_wantToEat && SceneController.foodOn == true)
        {
            text.GetComponent<TextMesh>().text = "Food found but not hungry";
            ani.SetBool("foodTargetOn", true);
        }
        else if (!m_wantToEat && SceneController.foodOn == false)
        {
            text.GetComponent<TextMesh>().text = "Food found but not hungry";
            ani.SetBool("foodTargetOn", false);
        }
        
        text2.GetComponent<TextMesh>().text = "Target:"+ ani.GetBool("foodTargetOn").ToString();
        text3.GetComponent<TextMesh>().text = "Position:"+ ani.GetBool("foodPosition").ToString();
        text4.GetComponent<TextMesh>().text = "Hunger:" + ani.GetFloat("hunger").ToString();

        HungerDec();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Cheese")
        {
            m_foodposition = true;
            ani.SetBool("foodPosition", true);

        }
       
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "LeaveCheese")
        {
            m_foodposition = false;
            ani.SetBool("foodPosition", false);
        }
    }

    void HungerDec()
    {
        if (m_foodposition == true && m_wantToEat)
        {
            m_hunger += 0.01f;
        }
        else 
        {
            m_hunger -= 0.005f;
        }

        if (m_hunger > 12)
        {
            m_wantToEat = false;
        }
        ani.SetFloat("hunger", m_hunger);
    }

  
}
