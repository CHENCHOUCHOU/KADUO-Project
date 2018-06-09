using UnityEngine;
using FairyGUI;
using UnityEngine.SceneManagement;
public class ComBoughtWindow: Window
{
	public ComBoughtWindow()
	{
	
	}
	
	protected override void OnInit()
	{
	          this.contentPane = UIPackage.CreateObject("Package1","ComBoughtWindow").asCom;
			  GButton okButton =  this.contentPane.GetChild("n2").asButton;
			  okButton.onClick.Set((EventContext) => {
			       this.Hide();
				   
        });
	}

	
		
	
}