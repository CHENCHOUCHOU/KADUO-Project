using FairyGUI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Authenticate : MonoBehaviour
{
    private GComponent mainUI;
    //public GTextField texts;          //宠物id文件
   // public TextAsset TxtFile;
    public string Mytxt;
    private CheckFailWindow1 checkFailWindow1;
    // Use this for initialization
    void Start()
    {
        mainUI = GetComponent<UIPanel>().ui;
        GButton okButton = mainUI.GetChild("n25").asButton;
        GButton resetButton = mainUI.GetChild("n26").asButton;
        checkFailWindow1 = new CheckFailWindow1();
        okButton.onClick.Add((EventContext) =>
        {
            //获取
            GTextField pet_code = mainUI.GetChild("n8").asTextField;
            //文件
            Mytxt = Resources.Load("pet_code").ToString();
            int flag = 0;
            string[] line = Mytxt.Split(new char[2] { '#', '\n' });
            for (int x = 0; x < line.Length; x++)
                    Debug.Log(line[x]);
            for (int x = 0; x < line.Length; x++)
            {
                //Debug.Log(line[x]);
                if (line[x] == pet_code.text)
                {
	    global.pet_id_global = line[x+1];
					//将激活的宠物id写入文件中
	    CreateOrOPenFile(Application.streamingAssetsPath+"/Resources","active_pets.txt",global.pet_id_global);
                    line[x+1] = line[x+1].Replace("\r", "");
					flag = 1;
                    SceneManager.LoadSceneAsync("mainScene");
                }
            }
			
			if(flag==0)
 {
	checkFailWindow1.SetXY((Screen.width-checkFailWindow1.width)/2,(Screen.height-checkFailWindow1.height)/2);
	checkFailWindow1.Show();
}
			
             
            //判断序列码
            // texts.text = Resources.Load("pet_code").ToString();

            //string[] line = texts.text.Split('#');
            //for (int x = 0; x < line.Length; x++)
            //     Debug.Log(line[x]);

            //  GTextField pet_id = mainUI.GetChild("n8").asTextField;


        });
		
		resetButton.onClick.Add((EventContext) =>
        {
			GTextField pet_code = mainUI.GetChild("n8").asTextField;
			pet_code.text = "";
		});

    }


    // Update is called once per frame
    void Update()
    {

    }
	
	void CreateOrOPenFile(string path, string name, string info){          //路径、文件名、写入内容
	StreamWriter sw; 
	FileInfo fi = new FileInfo(path + "//" + name);
	sw = fi.AppendText();        
	sw.WriteLine(info);
	sw.Close();
	sw.Dispose ();
	}
}
