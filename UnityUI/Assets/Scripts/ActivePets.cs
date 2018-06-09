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
			 Mytxt = ReadFile(Application.streamingAssetsPath+"/Resources/active_pets.txt");
			 Debug.Log(Mytxt);
			 midArray = Mytxt.Split(new char[]{'\n'});
			 for(int i=0;i<midArray.Length;i++){Debug.Log("m"+i + midArray[i]);}
			 
			 
			for(int i=0;i<midArray.Length;i++){
			midArray[i] = midArray[i].Replace("\r", "");
			global.activePets[i] = midArray[i];
			
			}
			 list =  mainUI.GetChild("ItemList").asList;
             list.itemRenderer =  RenderListItem;
             list.numItems = 3;
				 
            
         }
	    void Update () {
	   	 
			
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
	 
	public string ReadFile(string textPath) {
		
			byte[] dataBytes=new byte[12];  
            FileStream file = new FileStream(textPath, FileMode.Open);  
            file.Seek(0, SeekOrigin.Begin);  
            file.Read(dataBytes, 0, 12);  
            string readtext = Encoding.Default.GetString(dataBytes); 
			Debug.Log(readtext);			
            file.Close();  
            return readtext;  
        } 
	
 
}	
	
