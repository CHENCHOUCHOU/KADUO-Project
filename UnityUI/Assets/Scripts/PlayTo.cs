using FairyGUI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;

public class PlayTo : MonoBehaviour
{

    private GComponent mainUI;
    private BagWindow bagWindow;
    // Use this for initialization
	    int count = 0;
    void Start()
    {

        mainUI = GetComponent<UIPanel>().ui;
        GButton store = mainUI.GetChild("n8").asButton;
        GButton back = mainUI.GetChild("n9").asButton;
        GButton camera = mainUI.GetChild("n6").asButton;
        GButton bagButton = mainUI.GetChild("n21").asButton;
        bagWindow = new BagWindow();

        store.onClick.Set((EventContext) => {
            SceneManager.LoadSceneAsync("StoreScene");
        });
        back.onClick.Set((EventContext) => {
            SceneManager.LoadSceneAsync("MainScene");
        });

        camera.onClick.Set((EventContext) => {
           StartCoroutine(UploadJPG());
        });

       bagButton .onClick.Set((EventContext) => {
               bagWindow.SetXY(120,80);
			   bagWindow.Show();
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
		IEnumerator UploadJPG()
    {


        yield return new WaitForEndOfFrame();

        int width = 800;
        int height = 600;
        // 创建一个屏幕大小的纹理，RGB24 位格（24位格没有透明通道，32位的有）
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        // 读取屏幕内容到我们自定义的纹理图片中
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        // 保存前面对纹理的修改
        tex.Apply();
        // 编码纹理为JPG格式
        byte[] bytes = tex.EncodeToJPG();
        // 销毁无用的图片纹理
        Destroy(tex);
        count++;
        string photoName = "i" + count + ".JPG";
        File.WriteAllBytes(Application.persistentDataPath + photoName, bytes);
        WWW www = new WWW(Application.persistentDataPath + photoName);
        yield return www;

    }

}

