using FairyGUI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;
using Net;
using System;
using System.Security.Cryptography;

public class Authenticate : MonoBehaviour
{
    private GComponent mainUI;
    //public GTextField texts;          //宠物id文件
    // public TextAsset TxtFile;
    public string Mytxt;
    private CheckFailWindow1 checkFailWindow1;
    private CheckFailWindow2 checkFailWindow2;
    private AvoidCopyWindow avoidCopyWindow;
    private string[] midArray;
    // Use this for initialization
    void Start()
    {
        ClientSocket mSocket = new ClientSocket();
        mSocket.ConnectServer("192.168.43.34", 8088);
        string publickey = mSocket.Receive();

        mainUI = GetComponent<UIPanel>().ui;
        GButton okButton = mainUI.GetChild("n25").asButton;
        GButton resetButton = mainUI.GetChild("n26").asButton;
        GButton backButton = mainUI.GetChild("n28").asButton;
        checkFailWindow2 = new CheckFailWindow2();
        checkFailWindow1 = new CheckFailWindow1();
        avoidCopyWindow = new AvoidCopyWindow();
        okButton.onClick.Add((EventContext) =>
        {
            //获取
            GTextField pet_code = mainUI.GetChild("n8").asTextField;
            //文件
            Mytxt = Resources.Load("pet_code").ToString();
            int flag = 0;
            int flag1 = 0;
            string[] line = Mytxt.Split(new char[2] { '#', '\n' });
            for (int x = 0; x < line.Length; x++)
            {
                //Debug.Log(line[x]);
                if (line[x] == pet_code.text)
                {
                    flag = 1;
                    global.pet_id_global = line[x + 1];

                    Mytxt = File.ReadAllText(Application.persistentDataPath + "/active_pets.txt");
                    midArray = Mytxt.Split(new char[] { '\n' });


                    for (int i = 0; i < midArray.Length - 1; i++)
                    {


                        if (midArray[i].Length != 0)
                        {
                            string basecode = Base64Decode(midArray[i]);
                            //宠物id已激活
                            if (basecode == global.pet_id_global)
                            {
                                flag1 = 1;
                                Debug.Log("test");
                                checkFailWindow2.SetXY(170, 150);
                                checkFailWindow2.Show();
                                SceneManager.LoadSceneAsync("authenticationScene");
                            }
                        }
                    }
                    if (flag1 == 0)
                    {
                        line[x + 1] = line[x + 1].Replace("\r", "");
                        string str = "sequence#" + line[x + 1];
                        string str1 = RSAEncryption(str, publickey);
                        string judge = mSocket.SendMessage(str1);
                        int int_judge = Convert.ToInt32(judge);
                        if (int_judge == 4)
                        {
                            flag1 = 2;
                            avoidCopyWindow.SetXY(170, 150);
                            avoidCopyWindow.Show();
                            SceneManager.LoadSceneAsync("authenticationScene");
                        }
                    }
                    if (flag1 == 0)
                    {
                        //将激活的宠物id写入文件中
                        string id_encode = Base64Encode(global.pet_id_global);
                        CreateOrOPenFile(Application.persistentDataPath, "active_pets.txt", id_encode);
                        line[x + 1] = line[x + 1].Replace("\r", "");
                        flag = 1;
                        SceneManager.LoadSceneAsync("mainScene");
                    }
                }
            }
            //未匹配序列码，即序列码有误
            if (flag == 0)
            {
                checkFailWindow1.SetXY(170, 150);
                checkFailWindow1.Show();
                SceneManager.LoadSceneAsync("authenticationScene");
            }


        });

        resetButton.onClick.Add((EventContext) =>
        {
            GTextField pet_code = mainUI.GetChild("n8").asTextField;
            pet_code.text = "";
        });

        backButton.onClick.Add((EventContext) =>
        {
            SceneManager.LoadSceneAsync("mainScene");
        });

    }


    // Update is called once per frame
    void Update()
    {

    }


    void CreateOrOPenFile(string path, string name, string info)
    {          //路径、文件名、写入内容
        StreamWriter sw;
        FileInfo fi = new FileInfo(path + "//" + name);
        sw = fi.AppendText();
        sw.WriteLine(info);
        sw.Close();
        sw.Dispose();
    }

    public static string Base64Encode(string value)
    {
        string result = System.Convert.ToBase64String(Encoding.Default.GetBytes(value));
        return result;
    }

    public static string Base64Decode(string value)
    {
        string result = Encoding.Default.GetString(System.Convert.FromBase64String(value));
        return result;
    }


    public string RSAEncryption(string plaintext, string publickey)
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
}
