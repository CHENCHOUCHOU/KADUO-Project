using UnityEngine;
using FairyGUI;
using UnityEngine.SceneManagement;
public class CheckFailWindow2: Window
{
	public CheckFailWindow2()
	{
	
	}
	
	protected override void OnInit()
	{
	          this.contentPane = UIPackage.CreateObject("Package1","CheckFailWindow2").asCom;
			  GButton okButton =  this.contentPane.GetChild("n1").asButton;
			  okButton.onClick.Set((EventContext) => {
			       this.Hide();
        });
	}

	
		
	
}