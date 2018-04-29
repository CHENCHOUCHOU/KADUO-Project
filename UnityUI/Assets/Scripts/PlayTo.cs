using FairyGUI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayTo : MonoBehaviour
{
    private GComponent mainUI;
    // Use this for initialization
    void Start()
    {
        mainUI = GetComponent<UIPanel>().ui;
        GButton photo = mainUI.GetChild("n7").asButton;
        GButton store = mainUI.GetChild("n8").asButton;
        GButton back = mainUI.GetChild("n9").asButton;

        photo.onClick.Set((EventContext) => {
            SceneManager.LoadSceneAsync("PhotoScene");
        });
        store.onClick.Set((EventContext) => {
            SceneManager.LoadSceneAsync("StoreScene");
        });
        back.onClick.Set((EventContext) => {
            SceneManager.LoadSceneAsync("MainScene");
        });


    }

    // Update is called once per frame
    void Update()
    {

    }
}
