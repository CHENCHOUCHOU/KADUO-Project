using FairyGUI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class SignToMain : MonoBehaviour
{
    private GComponent mainUI;
    private LoginFailTipWindow loginFailTipWindow;
	private LoginSuccessWindow loginSuccessWindow;
    [DllImport("testDLL")]
    private static extern int Login(byte[] a, byte[] b, byte[] c);

    void Start()
    {
        mainUI = GetComponent<UIPanel>().ui;
        GButton login = mainUI.GetChild("n15").asButton;
        GButton register = mainUI.GetChild("n14").asButton;
        GTextField id = mainUI.GetChild("n8").asTextField;
        GTextField pass = mainUI.GetChild("n9").asTextField;
		
        loginFailTipWindow = new LoginFailTipWindow();
        loginSuccessWindow = new LoginSuccessWindow();
        login.onClick.Set((EventContext) => {
			
			//登录失败的弹框
           // loginFailTipWindow.SetXY(170,150);
            //loginFailTipWindow.Show();
			//登录成功的弹框
			loginSuccessWindow.SetXY(170,150);
			loginSuccessWindow.Show();
			
			
			
            string id1 = id.text;
            string pass1 = pass.text;
            byte[] id2 = System.Text.Encoding.Default.GetBytes(id1);
            byte[] pass2 = System.Text.Encoding.Default.GetBytes(pass1);
        
            int judge = Login(id2, pass2, pass2);
            if (judge == 0)
            {
                SceneManager.LoadSceneAsync("MainScene");
            }
            
        });
        register.onClick.Set((EventContext) => {
           

        });

    }

    // Update is called once per frame
    void Update()
    {

    }
}
