using FairyGUI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using System.Collections;
using Net;
using System;

public class SignToMain : MonoBehaviour
{
    private GComponent mainUI;
    private LoginFailTipWindow loginFailTipWindow;
	private LoginSuccessWindow loginSuccessWindow;
	private RegisterFailWindow registerFailWindow;
	private RegisterSuccessWindow registerSuccessWindow;
    [DllImport("testDLL")]
    private static extern int Login(byte[] a, byte[] b, byte[] c);

    void Start()
    {
        mainUI = GetComponent<UIPanel>().ui;
        GButton login = mainUI.GetChild("n15").asButton;
        GButton register = mainUI.GetChild("n14").asButton;
        GTextField id = mainUI.GetChild("n8").asTextField;
        GTextField pass = mainUI.GetChild("n9").asTextField;
		
		ClientSocket mSocket = new ClientSocket();
        mSocket.ConnectServer("172.24.48.6", 8088);
        loginFailTipWindow = new LoginFailTipWindow();
        loginSuccessWindow = new LoginSuccessWindow();
		registerFailWindow = new RegisterFailWindow();
		registerSuccessWindow = new RegisterSuccessWindow();
        login.onClick.Set((EventContext) => {
			
            string id1 = id.text;
            string pass1 = pass.text;
			
            string str = "login#" + id1 + "#" + pass1;
			string judge = mSocket.SendMessage(str);
            int int_judge = Convert.ToInt32(judge);
			
             if (int_judge == 2)
            {
				//登录失败的弹框
				loginFailTipWindow.SetXY(170,150);
				loginFailTipWindow.Show();

                SceneManager.LoadScene("signInScene");

            }

            if (int_judge == 3)
            {
                global.id_global = id1;
                //登录成功的弹框
                loginSuccessWindow.SetXY(170,150);
                loginSuccessWindow.Show();
            }
        });
		
        register.onClick.Set((EventContext) => {
            string id1 = id.text;
            string pass1 = pass.text;

            //转换成给服务器发送的标准格式
            //rigister # id # password
            string str = "register#" + id1 + "#" + pass1;

            string judge = mSocket.SendMessage(str);
            int int_judge = Convert.ToInt32(judge);

            //注册失败
            if (int_judge == 0)
            {
                registerFailWindow.SetXY(170,150);
                registerFailWindow.Show();
            }
			//注册成功
            if (int_judge == 1)
            {
               registerSuccessWindow.SetXY(170,150);
               registerSuccessWindow.Show();
            }
            SceneManager.LoadScene("signInScene");


        });

    }

    // Update is called once per frame
    void Update()
    {

    }
}
