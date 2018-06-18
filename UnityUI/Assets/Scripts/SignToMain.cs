using FairyGUI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using System.Collections;
using Net;
using System;
using System.Security.Cryptography;
using System.Text;

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
        mSocket.ConnectServer("192.168.43.34", 8088);
        string publickey = mSocket.Receive();

        loginFailTipWindow = new LoginFailTipWindow();
        loginSuccessWindow = new LoginSuccessWindow();
		registerFailWindow = new RegisterFailWindow();
		registerSuccessWindow = new RegisterSuccessWindow();
        login.onClick.Set((EventContext) => {
			
            string id1 = id.text;
            string pass1 = pass.text;

            

            string str = "login#" + id1 + "#" + pass1;
            string str1 = RSAEncryption(str,publickey);

            string judge = mSocket.SendMessage(str1);
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
            string str1 = RSAEncryption(str,publickey);
            string judge = mSocket.SendMessage(str1);
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

    public string RSAEncryption(string plaintext,string publickey)
    {
        RSACryptoServiceProvider rsa2 = new RSACryptoServiceProvider();
        rsa2.FromXmlString(publickey);   //rsa2   导入   rsa1   的公钥，用于加密信息   

        //rsa2开始加密   
        byte[] cipherbytes;
        cipherbytes = rsa2.Encrypt(
          Encoding.UTF8.GetBytes(plaintext),
          false);

        string cipherbytes1 = ToHexString(cipherbytes);
        
        return cipherbytes1;
    }
    public static string ToHexString(byte[] bytes) // 0xae00cf => "AE00CF "

    {
        string hexString = string.Empty;

        if (bytes != null)

        {

            StringBuilder strB = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)

            {

                strB.Append(bytes[i].ToString("X2"));

            }

            hexString = strB.ToString();

        }
        return hexString;

    }
    // Update is called once per frame
    void Update()
    {

    }
}
