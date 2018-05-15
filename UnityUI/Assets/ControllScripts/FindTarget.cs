using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindTarget : MonoBehaviour {

    public GameObject target;
    public GameObject character;
    public GameObject text,text2,text3;

    private CharacterController chaCon;
    private Animator ani;

	// Use this for initialization
	void Start () {
        character = this.gameObject;
        ani = this.transform.GetComponent<Animator>();
        ani.SetBool("foodPosition", false);
        chaCon = this.transform.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneController.foodOn == true)
        {
            text.GetComponent<TextMesh>().text = "Found";
            character.transform.LookAt(target.transform);
            if (ani.GetBool("foodPosition")==false)
            chaCon.Move(this.transform.forward * 70.0f * Time.deltaTime);
            ani.SetBool("foodTargetOn", true);
        }
        else
        {
            text.GetComponent<TextMesh>().text = "Offline";
            ani.SetBool("foodTargetOn", false);
        }

        text2.GetComponent<TextMesh>().text = "Target:"+ ani.GetBool("foodTargetOn").ToString();
        text3.GetComponent<TextMesh>().text = "Position:"+ ani.GetBool("foodPosition").ToString();


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Cheese")
        {
            
            ani.SetBool("foodPosition", true);

        }
       
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "LeaveCheese")
        {
            ani.SetBool("foodPosition", false);
        }
    }
}
