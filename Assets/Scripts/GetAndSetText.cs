using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public  class GetAndSetText : MonoBehaviour {
    
    public InputField ime;
    public Text fText;
    private GameObject myObject;
    private int secondsToWait = 4;
    public int levelToLoad = 4;

	public void setget ()
	{
		fText.text = "No, prijatelj " + ime.text + ", pa pojdiva na sprehod po moji življenski poti.";
        VariableBase.PlayerName = ime.text;

        StartCoroutine(TransitionToNextScene());
        
	}
    
    IEnumerator TransitionToNextScene() {

        Debug.Log(PlayerPrefs.GetString("Ime"));

        yield return new WaitForSeconds(secondsToWait);

        SceneManager.LoadScene(VariableBase.LevelNumber);
    }

}