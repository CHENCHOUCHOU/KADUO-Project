using FairyGUI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Authenticate : MonoBehaviour
{
    private GComponent mainUI;
    // Use this for initialization
    void Start()
    {
        mainUI = GetComponent<UIPanel>().ui;
        GButton okButton = mainUI.GetChild("n25").asButton;
        GButton resetButton = mainUI.GetChild("n26").asButton;


        okButton.onClick.Set((EventContext) =>
        {
            SceneManager.LoadSceneAsync("mainScene");
        });


        resetButton.onClick.Set((EventContext) =>
        {
            
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
