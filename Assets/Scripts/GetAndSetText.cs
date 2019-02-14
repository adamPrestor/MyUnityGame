using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public  class GetAndSetText : MonoBehaviour {
    
    public InputField ime;
    public Text fText;
    public CanvasGroup cg;
    

	public void setget ()
	{
		fText.text = "No, prijatelj " + ime.text + ", pa pojdiva na sprehod po moji življenski poti.";
        VariableBase.PlayerName = ime.text;

        Hide_test.show_selected(cg);
        
	}

}