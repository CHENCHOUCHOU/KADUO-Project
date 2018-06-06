using UnityEngine;
using FairyGUI;
using UnityEngine.SceneManagement;
public class CheckFailWindow1: Window
{
	public CheckFailWindow1()
	{
	
	}
	
	protected override void OnInit()
	{
	          this.contentPane = UIPackage.CreateObject("Package1","CheckFailWindow1").asCom;
			  GButton okButton =  this.contentPane.GetChild("n2").asButton;
			  okButton.onClick.Set((EventContext) => {
			       this.Hide();
        });
	}

	
		
	
}