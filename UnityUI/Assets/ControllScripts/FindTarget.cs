using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindTarget : MonoBehaviour {

    public GameObject target;
    public GameObject character;
    public GameObject text;

	// Use this for initialization
	void Start () {
        character = this.gameObject;	
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneController.foodOn == true)
        {
            text.GetComponent<TextMesh>().text = "Found";
            character.transform.LookAt(target.transform);
        }
        else
        {
            text.GetComponent<TextMesh>().text = "Offline";
        }
    }
}
