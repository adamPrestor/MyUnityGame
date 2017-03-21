using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Naprej : MonoBehaviour {
	
	public int levelToLoad;
	
	public void LoadScene()
    {
        SceneManager.LoadScene(levelToLoad);
    }
	
}

