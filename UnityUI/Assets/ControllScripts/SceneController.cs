using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    static public bool characterOn;
    static public bool foodOn;
    static public bool foodPosition;
    


	// Use this for initialization
	void Start () {

        foodPosition = false;
        characterOn = false;
        foodOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
