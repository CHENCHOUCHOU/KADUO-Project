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
        GButton playButton = mainUI.GetChild("playButton").asButton;
        GButton addButton = mainUI.GetChild("addButton").asButton;


        playButton.onClick.Set((EventContext) =>
        {
            SceneManager.LoadSceneAsync("PlayScene");
        });


        addButton.onClick.Set((EventContext) =>
        {
            SceneManager.LoadSceneAsync("authenticationScene");
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
