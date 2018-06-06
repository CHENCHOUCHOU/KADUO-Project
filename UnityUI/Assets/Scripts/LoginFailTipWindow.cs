using UnityEngine;
using FairyGUI;
using UnityEngine.SceneManagement;
public class LoginFailTipWindow: Window
{
	public LoginFailTipWindow()
	{
	
	}
	
	protected override void OnInit()
	{
	          this.contentPane = UIPackage.CreateObject("Package1","FailWindow").asCom;
			  GButton okButton =  this.contentPane.GetChild("n6").asButton;
			  okButton.onClick.Set((EventContext) => {
			       this.Hide();
				   
        });
	}

	
		
	
}