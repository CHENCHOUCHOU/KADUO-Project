using FairyGUI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainToPlay : MonoBehaviour
{
    private GComponent mainUI;
    // Use this for initialization
    void Start()
    {
        mainUI = GetComponent<UIPanel>().ui;
        GButton choice1 = mainUI.GetChild("n15").asButton;
        GButton choice2 = mainUI.GetChild("n14").asButton;
        GButton choice3 = mainUI.GetChild("n14").asButton;

        choice1.onClick.Set((EventContext) => {
            SceneManager.LoadSceneAsync("PlayScene");
        });
        choice2.onClick.Set((EventContext) => {
            SceneManager.LoadSceneAsync("PlayScene");
        });
        choice3.onClick.Set((EventContext) => {
            SceneManager.LoadSceneAsync("PlayScene");
        });

    }

    // Update is called once per frame
    void Update()
    {

    }
}
