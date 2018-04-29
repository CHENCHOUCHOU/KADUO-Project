using System.Collections;

using System.Collections.Generic;

using UnityEngine;
using FairyGUI;
using UnityEngine.SceneManagement;

public class ActivePets : MonoBehaviour {

	
        private GList list;
        private GComponent mainUI;
	void Start () {
	
             mainUI = GetComponent<UIPanel>().ui;
             list =  mainUI.GetChild("ItemList").asList;
             list.itemRenderer =  RenderListItem;
             list.numItems = 3;
	     for(int i=0;i< list.numItems;i++){
                           GButton button = list.GetChildAt(i).asButton;
                           button.onClick.Add(() => { SceneManager.LoadSceneAsync("playScene"); });
              }


	
	}


private void RenderListItem(int index,GObject obj){

           GButton button = obj.asButton;
	       button.icon = UIPackage.GetItemURL("Package1", "i"+index);
           button.title = index.ToString();
}	
	

}
