using UnityEngine;
using FairyGUI;
using UnityEngine.SceneManagement;

public class StoreTo : MonoBehaviour {

    private GComponent mainUI;
    void Start () {

        mainUI = GetComponent<UIPanel>().ui;
        GButton backButton = mainUI.GetChild("backButton").asButton;

        backButton.onClick.Set((EventContext) => {
            SceneManager.LoadSceneAsync("PlayScene");
        });
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
