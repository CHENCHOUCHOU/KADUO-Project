using FairyGUI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartToSign : MonoBehaviour {
    private GComponent mainUI;
    // Use this for initialization
    void Start () {
        mainUI = GetComponent<UIPanel>().ui;
        GButton start = mainUI.GetChild("n2").asButton;
        GButton quit = mainUI.GetChild("n3").asButton;
        
        start.onClick.Set((EventContext) => {
            SceneManager.LoadScene("signInScene");
        });
        quit.onClick.Set((EventContext) => {
            Application.Quit();
            
        });
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
