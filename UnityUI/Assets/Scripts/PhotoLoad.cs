using UnityEngine;
using FairyGUI;
using UnityEngine.SceneManagement;
using System.IO;
public class PhotoLoad : MonoBehaviour
{

    private GList list;
    private GComponent mainUI;
    void Start()
    {
      
    }

    void Update()
    {
        mainUI = GetComponent<UIPanel>().ui;
        GButton backButton = mainUI.GetChild("n19").asButton;
        list = mainUI.GetChild("n15").asList;
        list.itemRenderer = RenderListItem;
        list.numItems = 8;

        backButton.onClick.Set((EventContext) =>
        {
            SceneManager.LoadSceneAsync("PlayScene");
        });

        for (int i = 0; i < list.numItems; i++)
        {
            GButton button = list.GetChildAt(i).asButton;
            button.onClick.Add(() => { });
            //图片放大
        }
    }

        private void RenderListItem(int index, GObject obj)
        {
            GButton button = obj.asButton;
            button.icon = "photos/i"  + index;
            button.title = index.ToString();
        }

    
}




 