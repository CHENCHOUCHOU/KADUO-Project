using UnityEngine;
using FairyGUI;
using UnityEngine.SceneManagement;
public class RegisterFailWindow: Window
{
	public RegisterFailWindow()
	{
	
	}
	
	protected override void OnInit()
	{
	          this.contentPane = UIPackage.CreateObject("Package1","RegisterFailWindow").asCom;
			  GButton okButton =  this.contentPane.GetChild("n4").asButton;
			  okButton.onClick.Set((EventContext) => {
				   this.Hide();	   
        });
	}	
}