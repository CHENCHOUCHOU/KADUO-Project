using UnityEngine;
using FairyGUI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;
public class CommodityWindow : Window
{
	private GameObject commodity;
	private ComBoughtWindow comBoughtWindow;
	public string Mytxt;
	
	public CommodityWindow(GameObject commodity)
	{
		this.commodity = commodity;
	}
	
	protected override void OnInit()
	{
        this.contentPane = UIPackage.CreateObject("Package1","commodityWindow").asCom;
		
        GLoader loader = this.contentPane.GetChild("n8").asLoader;
        loader.url = UIPackage.GetItemURL("Package1","s0");
		comBoughtWindow = new ComBoughtWindow();
		GButton buyButton =  this.contentPane.GetChild("buyToBag").asButton;
		int flag = 0;
		buyButton.onClick.Set((EventContext) => {
			//获取用户选择的道具ID
			global.bag_id_global = "s0";
			string bagEncode = Base64Encode(global.bag_id_global);
            //读出bag中的道具
            string path = Application.persistentDataPath + "/bought_to_bag.txt";
            if (File.Exists(path))
            {
                Mytxt = File.ReadAllText(Application.persistentDataPath + "/bought_to_bag.txt");
                //如果道具id与bag中的道具一样
                string[] line = Mytxt.Split(new char[] { '\n' });
                for(int i=0;i<line.Length-1;i++)
			 {
				line[i] = line[i].Replace("\r", "");
				if(bagEncode==line[i])
				{
					flag = 1;
					comBoughtWindow.SetXY(170,150);
					comBoughtWindow.Show();
				}
			 }
			 if(flag == 0)
			 {
				CreateOrOPenFile(Application.persistentDataPath,"bought_to_bag.txt",bagEncode);
				this.Hide();
			 }
            }
            else
            {
                StreamWriter st = File.CreateText(path);
            }
           
            // Texture2D texture = new Texture2D(120,120);
            /* string foundedImgPath = Application.streamingAssetsPath +"/Resources/store/" + imgName;
             FileStream files = new FileStream(foundedImgPath, FileMode.Open);
             byte[] imgByte = new byte[files.Length];
             files.Read(imgByte, 0, imgByte.Length);
             files.Close();
             int count = 0;
             DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath + "/Resources/bag");
             foreach (FileInfo FI in dir.GetFiles())
             {
                 // 这里写文件格式
                 if (System.IO.Path.GetExtension(FI.Name) == ".PNG")
                 {
                     count++;
                 }
             }
             string photoName = "i" + count + ".PNG";
             File.WriteAllBytes(Application.persistentDataPath + "/Resources/bag/"+ photoName, imgByte);
             AssetDatabase.Refresh();*/

        });
    }

	
void CreateOrOPenFile(string path, string name, string info){          //路径、文件名、写入内容
	StreamWriter sw; 
	FileInfo fi = new FileInfo(path + "//" + name);
	sw = fi.AppendText();        
	sw.WriteLine(info);
	sw.Close();
	sw.Dispose ();
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
	
}