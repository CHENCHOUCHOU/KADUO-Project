using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour {

    Animator ani;
	// Use this for initialization
	void Start () {
        ani = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        
        if (other.name == "Cheese")
        {
            SceneController.foodPosition = true;
            ani.SetBool("foodPosition", true);

        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "LeaveCheese")
        {
            SceneController.foodPosition = false;
            ani.SetBool("foodPosition", false);
        }
    }
}
