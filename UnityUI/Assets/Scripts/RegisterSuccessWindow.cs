using UnityEngine;
using FairyGUI;
using UnityEngine.SceneManagement;
public class RegisterSuccessWindow: Window
{
	public RegisterSuccessWindow()
	{
	
	}
	
	protected override void OnInit()
	{
	          this.contentPane = UIPackage.CreateObject("Package1","RegisterSuccessWindow").asCom;
			  GButton okButton =  this.contentPane.GetChild("n4").asButton;
			  okButton.onClick.Set((EventContext) => {
				   this.Hide();
				   
        });
	}	
}