using UnityEngine;
using FairyGUI;
using UnityEngine.SceneManagement;
public class StoreTo : MonoBehaviour {

    private GComponent mainUI;
    private GList list;
    private CommodityWindow commodityWindow;
    private GameObject commodity;
	private GButton buyView;

	void Start () {

       
    }
	
	// Update is called once per frame
	void Update () {
		mainUI = GetComponent<UIPanel>().ui;
		
		list =  mainUI.GetChild("n9").asList;
        list.itemRenderer =  RenderListItem;
        list.numItems = 8;
        GButton backButton = mainUI.GetChild("backButton").asButton;
		commodityWindow = new CommodityWindow();
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
		 button.title = "s"+index;
}	

private void ClickItem(GButton button)
{
	commodityWindow.setButton(button);
	commodityWindow.SetXY(170,100);
	commodityWindow.Show(); 
	
}

}
