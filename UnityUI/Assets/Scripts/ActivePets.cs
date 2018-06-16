using UnityEngine;
using FairyGUI;
using System.IO;
using System.Text;
public class ActivePets : MonoBehaviour {


        private GList list;
        private GComponent mainUI;
		private string Mytxt;
		private string[] midArray;
         void Start()
         {
			 mainUI = GetComponent<UIPanel>().ui;
        //从文件读取获得已激活的宠物id数组
        // WWW www = new WWW(Application.streamingAssetsPath + "/Resources/active_pets.txt");

        // Mytxt = www.text;

        // Mytxt = ReadFile(Application.streamingAssetsPath + "/Resources/active_pets.txt");
        string path = Application.persistentDataPath + "/active_pets.txt";
        if (File.Exists(path))
        {

            string Mytxt = File.ReadAllText(Application.persistentDataPath + "/active_pets.txt");
            Debug.Log(Mytxt);
            midArray = Mytxt.Split(new char[] { '\n' });

            for (int i = 0; i < midArray.Length-1; i++)
        {
               midArray[i] = midArray[i].Replace("\r", "");
			
			   if(midArray[i].Length!=0)
			{  
			   global.activePets[i] = Base64Decode(midArray[i]);
		       global.activePets[i] = global.activePets[i].Replace("\r","");
			}
	    }

            list = mainUI.GetChild("ItemList").asList;
            list.itemRenderer = RenderListItem;
            list.numItems = 3;

        }
        else
        {
            StreamWriter st = File.CreateText(path);
        }
         }
	    void Update () {
        //更新用户名
        GTextField id = mainUI.GetChild("n6").asTextField;
        id.text = global.id_global;

    }


    private void RenderListItem(int index,GObject obj){
	     
         GButton button = obj.asButton;
		 string petId = "i"+index;
		 for(int i=0;i<global.activePets.Length;i++)
		 {
			 if(petId == global.activePets[i])
				 button.icon =  UIPackage.GetItemURL("Package1",petId);
		 }
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
	
