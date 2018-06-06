using UnityEngine;
using FairyGUI;
using UnityEngine.SceneManagement;
using System.IO;
public class CommodityWindow : Window
{
	private GameObject commodity;
	public CommodityWindow(GameObject commodity)
	{
		this.commodity = commodity;
	}
	
	protected override void OnInit()
	{
        this.contentPane = UIPackage.CreateObject("Package1","commodityWindow").asCom;
		
        GLoader loader = this.contentPane.GetChild("n8").asLoader;
        loader.url = UIPackage.GetItemURL("Package1","s0");
		
		GButton buyButton =  this.contentPane.GetChild("buyToBag").asButton;
		buyButton.onClick.Set((EventContext) => {
			//将道具放入（写入）道具包中
			global.bag_id_global = "s0";
			CreateOrOPenFile(Application.streamingAssetsPath+"/Resources","bought_to_bag.txt",global.bag_id_global);
			this.Hide();
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
	
	
		
	
}