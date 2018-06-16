using UnityEngine;
using FairyGUI;
using UnityEngine.SceneManagement;
public class AvoidCopyWindow: Window
{
	public AvoidCopyWindow()
	{
	
	}
	
	protected override void OnInit()
	{
	          this.contentPane = UIPackage.CreateObject("Package1","AvoidCopyWindow").asCom;
			  GButton okButton =  this.contentPane.GetChild("n4").asButton;
			  okButton.onClick.Set((EventContext) => {
				   this.Hide();
				   
        });
	}	
}