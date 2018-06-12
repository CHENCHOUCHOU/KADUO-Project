using FairyGUI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;

public class Authenticate : MonoBehaviour
{
    private GComponent mainUI;
    //public GTextField texts;          //宠物id文件
   // public TextAsset TxtFile;
    public string Mytxt;
    private CheckFailWindow1 checkFailWindow1;
	private CheckFailWindow2 checkFailWindow2;
	private string[] midArray;
    // Use this for initialization
    void Start()
    {
        mainUI = GetComponent<UIPanel>().ui;
        GButton okButton = mainUI.GetChild("n25").asButton;
        GButton resetButton = mainUI.GetChild("n26").asButton;
		GButton backButton = mainUI.GetChild("n28").asButton;
		checkFailWindow2 = new CheckFailWindow2();
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
					flag = 1;
					global.pet_id_global = line[x+1];
                    //如果宠物的id已经存储，则提示宠物已激活
                    //Mytxt = ReadFile(Application.streamingAssetsPath+"/Resources/active_pets.txt");
                     Mytxt = File.ReadAllText(Application.persistentDataPath + "/active_pets.txt"); 
                     midArray = Mytxt.Split(new char[]{'\n'});
					//i0,i1,
				    int flag1 = 0;
				for(int i=0;i<midArray.Length;i++)
				{
					midArray[i] = midArray[i].Replace("\r", "");
					Debug.Log("H "+midArray[i]);
					Debug.Log("global.pet_id_global "+global.pet_id_global);
					
					if(midArray[i]+"\r"==global.pet_id_global)
					{
						flag1 = 1;
						Debug.Log("test");
						checkFailWindow2.SetXY(170,150);
						checkFailWindow2.Show();
					}
				}
				 if(flag1==0){
					//将激活的宠物id写入文件中
					CreateOrOPenFile(Application.persistentDataPath ,"active_pets.txt",global.pet_id_global);
                    line[x+1] = line[x+1].Replace("\r", "");
					flag = 1;
                    SceneManager.LoadSceneAsync("mainScene");
				 }
                }
            }
			//未匹配序列码，即序列码有误
				if(flag==0)
			{
				checkFailWindow1.SetXY(170,150);
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
		
		backButton.onClick.Add((EventContext) =>
        {
			 SceneManager.LoadSceneAsync("mainScene");
		});

    }


    // Update is called once per frame
    void Update()
    {

    }
	
		 
	/*public string ReadFile(string textPath) {
		
			byte[] dataBytes=new byte[12];  
            FileStream file = new FileStream(textPath, FileMode.Open);  
            file.Seek(0, SeekOrigin.Begin);  
            file.Read(dataBytes, 0, 12);  
            string readtext = Encoding.Default.GetString(dataBytes); 
			Debug.Log(readtext);			
            file.Close();  
            return readtext;  
        } 
	*/
	void CreateOrOPenFile(string path, string name, string info){          //路径、文件名、写入内容
	StreamWriter sw; 
	FileInfo fi = new FileInfo(path + "//" + name);
	sw = fi.AppendText();        
	sw.WriteLine(info);
	sw.Close();
	sw.Dispose ();
	}
}
