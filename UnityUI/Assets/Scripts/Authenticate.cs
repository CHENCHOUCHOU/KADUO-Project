using FairyGUI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class Authenticate : MonoBehaviour
{
    private GComponent mainUI;
    // Use this for initialization
    [DllImport("testDLL")]
    private static extern int ser(byte[] a, byte[] b);
    void Start()
    {
        mainUI = GetComponent<UIPanel>().ui;
        GButton okButton = mainUI.GetChild("n25").asButton;
        GButton resetButton = mainUI.GetChild("n26").asButton;
        GTextField cdkey = mainUI.GetChild("n8").asTextField;

        okButton.onClick.Set((EventContext) =>
        {
            string cdkey1 = cdkey.text;
            
            byte[] cdkey2 = System.Text.Encoding.Default.GetBytes(cdkey1);
            

            int judge = ser(cdkey2, cdkey2);
            if (judge == 0)
            {
                SceneManager.LoadSceneAsync("mainScene");
            }
            
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
