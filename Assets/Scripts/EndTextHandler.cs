using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTextHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<ComplexDialogHandler>().onStartDialog();
        StartCoroutine(EndGame());
	}
	
    IEnumerator EndGame()
    {

        yield return new WaitForSeconds(28.0f);
        
        SceneManager.LoadScene(0);
        
    }

}
