using FairyGUI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignToMain : MonoBehaviour
{
    private GComponent mainUI;
    // Use this for initialization
    void Start()
    {
        mainUI = GetComponent<UIPanel>().ui;
        GButton login = mainUI.GetChild("n15").asButton;
        GButton register = mainUI.GetChild("n14").asButton;

        login.onClick.Set((EventContext) => {
            SceneManager.LoadSceneAsync("MainScene");
        });
        register.onClick.Set((EventContext) => {
           

        });

    }

    // Update is called once per frame
    void Update()
    {

    }
}
