using UnityEngine;
using FairyGUI;

public class ActivePets : MonoBehaviour {


        private GList list;
        private GComponent mainUI;

         void Start()
         {
        
         }
	    void Update () {
	    
             mainUI = GetComponent<UIPanel>().ui;
             list =  mainUI.GetChild("ItemList").asList;
             list.itemRenderer =  RenderListItem;
             list.numItems = 3;
	
	}


private void RenderListItem(int index,GObject obj){
         GButton button = obj.asButton;
         button.icon = "pets/i" +index;
         button.title = index.ToString();
}	
	

}
