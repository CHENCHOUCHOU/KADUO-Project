using UnityEngine;
using FairyGUI;
using UnityEngine.SceneManagement;
public class StoreTo : MonoBehaviour {

    private GComponent mainUI;
    private GList list;
    private CommodityWindow commodityWindow;
    private GameObject commodity;
	 
    void Start () {

       
    }
	
	// Update is called once per frame
	void Update () {
		mainUI = GetComponent<UIPanel>().ui;
		commodityWindow = new CommodityWindow(commodity);
		list =  mainUI.GetChild("n9").asList;
        list.itemRenderer =  RenderListItem;
        list.numItems = 8;
        GButton backButton = mainUI.GetChild("backButton").asButton;

        backButton.onClick.Set((EventContext) => {
            SceneManager.LoadSceneAsync("PlayScene");
        });
		
		for (int i = 0; i < list.numItems; i++)
        {
			GButton button = list.GetChildAt(i).asButton;
            button.onClick.Add((EventContext) => { 
			ClickItem(button);
			});
            
        }
	}
	
	
private void RenderListItem(int index,GObject obj){
         GButton button = obj.asButton;
         button.icon = UIPackage.GetItemURL("Package1","s"+index);
}	

private void ClickItem(GButton button)
{
	
	commodityWindow.SetXY(150,80);
	commodityWindow.Show(); 
	
}

}
