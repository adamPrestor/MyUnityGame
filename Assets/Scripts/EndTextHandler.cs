using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTextHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(EndGame());
	}
	
    IEnumerator EndGame()
    {

        yield return new WaitForSeconds(8.0f);

        SceneManager.LoadScene(0);
        
    }

}
