using UnityEngine;
using FairyGUI;
using UnityEngine.SceneManagement;
using System.Text;
using System.IO;
public class BagWindow : Window
{
	
	private GList list;
	private string Mytxt;
	private string[] midArray;
	public BagWindow ()
	{
	
	}
	
	protected override void OnInit()
	{
		
       	   this.contentPane = UIPackage.CreateObject("Package1","BagWindow").asCom;
		   Mytxt = ReadFile(Application.streamingAssetsPath+"/Resources/bought_to_bag.txt");
		   midArray = Mytxt.Split(new char[]{'\n'});
			
			for(int i=0;i<midArray.Length-1;i++){
			midArray[i] = midArray[i].Replace("\r", "");
			global.in_bag[i] = midArray[i];
			}
			
      	  list = this.contentPane.GetChild("n1").asList;
		  list.itemRenderer = RenderListItem;
	      list.numItems = 6;

	for (int i = 0; i < list.numItems; i++)
             {
				GButton button = list.GetChildAt(i).asButton;
                button.onClick.Add((EventContext) => {  this.Hide(); });
             }

}

	public void RenderListItem(int index,GObject obj)
	{
		
		GButton button = obj.asButton;
	                 string bagId = "s"+index;
		 for(int i=0;i<global.in_bag.Length;i++)
		 {
			 if(bagId == global.in_bag[i])
			 button.icon =  UIPackage.GetItemURL("Package1",bagId);
		 } 
	}
	
		public string ReadFile(string textPath) {
		
			byte[] dataBytes=new byte[10];  
            FileStream file = new FileStream(textPath, FileMode.Open);  
            file.Seek(0, SeekOrigin.Begin);  
            file.Read(dataBytes, 0, 10);  
            string readtext = Encoding.Default.GetString(dataBytes);  
            file.Close();  
            return readtext;  
        } 
		
	
}