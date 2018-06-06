using UnityEngine;
using FairyGUI;
using UnityEngine.SceneManagement;
public class LoginSuccessWindow: Window
{
	public LoginSuccessWindow()
	{
	
	}
	
	protected override void OnInit()
	{
	          this.contentPane = UIPackage.CreateObject("Package1","SuccessWindow").asCom;
			  GButton okButton =  this.contentPane.GetChild("n1").asButton;
			  okButton.onClick.Set((EventContext) => {
			       SceneManager.LoadSceneAsync("MainScene");
				   this.Hide();
				   
        });
	}	
}