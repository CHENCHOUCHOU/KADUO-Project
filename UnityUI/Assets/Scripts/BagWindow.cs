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
		   GButton cancelButton =  this.contentPane.GetChild("n2").asButton;
		    cancelButton.onClick.Set((EventContext) => {
				   GameObject.Find("ImageTarget").GetComponent<FindTarget>().ChangePetSkinToOrigin();
				   this.Hide();
				   
        });
		   Mytxt = File.ReadAllText(Application.persistentDataPath + "/bought_to_bag.txt");
           midArray = Mytxt.Split(new char[]{'\n'});
			
			for(int i=0;i<midArray.Length-1;i++)
			{
				midArray[i] = midArray[i].Replace("\r", "");
				global.in_bag[i] = 	Base64Decode(midArray[i]);
				global.in_bag[i] = global.in_bag[i].Replace("\r","");
			}
			
      	  list = this.contentPane.GetChild("n1").asList;
		  list.itemRenderer = RenderListItem;
	      list.numItems = 6;

	for (int i = 0; i < list.numItems; i++)
             {
				GButton button = list.GetChildAt(i).asButton;
                button.onClick.Add((EventContext) => { 
				if(button.title=="s0"){
						GameObject.Find("ImageTarget").GetComponent<FindTarget>().ChangePetSkinTogirl();}
				else if(button.title=="s1"){
						GameObject.Find("ImageTarget").GetComponent<FindTarget>().ChangePetSkinToboy();
				}
				this.Hide(); });
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
		     button.title = bagId;
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