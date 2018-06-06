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
    void Start()
    {

        mainUI = GetComponent<UIPanel>().ui;
        GButton photo = mainUI.GetChild("n7").asButton;
        GButton store = mainUI.GetChild("n8").asButton;
        GButton back = mainUI.GetChild("n9").asButton;
        GButton camera = mainUI.GetChild("n6").asButton;
        GButton bagButton = mainUI.GetChild("n21").asButton;
        bagWindow = new BagWindow();


        photo.onClick.Set((EventContext) => {
            SceneManager.LoadSceneAsync("PhotoScene");
        });
        store.onClick.Set((EventContext) => {
            SceneManager.LoadSceneAsync("StoreScene");
        });
        back.onClick.Set((EventContext) => {
            SceneManager.LoadSceneAsync("MainScene");
        });

        camera.onClick.Set((EventContext) => {
           StartCoroutine(UploadPNG());
        });

       bagButton .onClick.Set((EventContext) => {
               bagWindow.SetXY((Screen.width-bagWindow.width)/2,(Screen.height-bagWindow.height)/2);
	bagWindow.Show();
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator UploadPNG()
    {

        yield return new WaitForEndOfFrame();

        int width = 120;
        int height = 120;
        // 创建一个屏幕大小的纹理，RGB24 位格（24位格没有透明通道，32位的有）
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        // 读取屏幕内容到我们自定义的纹理图片中
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        // 保存前面对纹理的修改
        tex.Apply();
        // 编码纹理为PNG格式
        byte[] bytes = tex.EncodeToPNG();
        // 销毁无用的图片纹理
        Destroy(tex);
       int count = 0;
	  DirectoryInfo dir = new DirectoryInfo(Application.streamingAssetsPath + "/Resources/photos");
      foreach (FileInfo FI in dir.GetFiles())
       {
            // 这里写文件格式
        if (System.IO.Path.GetExtension(FI.Name) == ".PNG")
        {
             count++;
        }
      }
        string photoName = "i" + count + ".PNG";
        File.WriteAllBytes(Application.streamingAssetsPath + "/Resources/photos/" + photoName, bytes);
    }


    //public IEnumerator Capture2()
    // {

    //     Rect rect = new Rect();
    //     // 先创建一个的空纹理，大小可根据实现需要来设置
    //     rect.width = Screen.width;
    //     rect.height = Screen.height;
    //     Texture2D screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);

    //     // 读取屏幕像素信息并存储为纹理数据  
    //     yield return new WaitForEndOfFrame();
    //     screenShot.ReadPixels(rect, 0, 0, false);
    //     screenShot.Apply();

    //     // 然后将这些纹理数据，成一个png图片文件    
    //     byte[] bytes = screenShot.EncodeToPNG();
    //     Image image = GetImage(bytes);//这里做 byte[] 转 image
    //     int count = 0;

    //     if (Application.platform == RuntimePlatform.Android)
    //     {
    //         string destination = "/sdcard/DCIM/Camera/ScreenPhotos";
    //         if (!Directory.Exists(destination))
    //         {
    //             Directory.CreateDirectory(destination);
    //         }
    //         DirectoryInfo dir = new DirectoryInfo(destination);
    //         foreach (FileInfo FI in dir.GetFiles())
    //         {
    //             // 这里写文件格式
    //             if (System.IO.Path.GetExtension(FI.Name) == ".PNG")
    //             {
    //                 count++;
    //             }
    //         }
    //         string photoName = "i" + count + ".PNG";
    //         string filename = destination + "/" + photoName;
    //         KiResizeImage(new Bitmap(image), 120, 120).Save(filename, System.Drawing.Imaging.ImageFormat.PNG);

    //     }
    // }
    //     // <summary>
    //     // 二进制数组转image
    //     public Image GetImage(byte[] byteArrayIn)
    //     {
    //         if (byteArrayIn == null)
    //             return null;
    //         using (System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArrayIn))
    //         {
    //             System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
    //             ms.Flush();
    //             return returnImage;
    //         }
    //     }

    //     public static Bitmap KiResizeImage(Bitmap bmp, int newW, int newH)
    //     {
    //         try
    //         {
    //             Bitmap b = new Bitmap(newW, newH);
    //             System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(b);
    //             // 插值算法的质量
    //             g.InterpolationMode = InterpolationMode.HighQualityBicubic;
    //             g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
    //             g.Dispose();
    //             return b;
    //         }
    //         catch
    //         {
    //             return null;
    //         }
    //     }


}

