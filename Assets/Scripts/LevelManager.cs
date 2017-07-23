﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public Transform mainMenu, optionsMenu, optionsMenu2;


	public void LoadScene(int i){
		SceneManager.LoadScene (i);
	}

	public void QuitGame (){
		Application.Quit();
	}

	public void Menu (bool clicked){
		if (clicked == true) {
			mainMenu.gameObject.SetActive (clicked);
			mainMenu.gameObject.SetActive (false);
		} else {
			mainMenu.gameObject.SetActive (clicked);
			mainMenu.gameObject.SetActive (true);
		}
	}

	public void OptionsMenu (bool clicked){
		if (clicked == true) {
			optionsMenu.gameObject.SetActive (clicked);
			mainMenu.gameObject.SetActive (false);
		} else {
			optionsMenu.gameObject.SetActive (clicked);
			mainMenu.gameObject.SetActive (true);
		}
	}

	public void OptionsMenu2 (bool clicked){
		if (clicked == true) {
			optionsMenu2.gameObject.SetActive (clicked);
			mainMenu.gameObject.SetActive (false);
		} else {
			optionsMenu2.gameObject.SetActive (clicked);
			mainMenu.gameObject.SetActive (true);
		}
	}

    public void aboutGame ()
    {
        Debug.Log(Application.dataPath);
        string path = Application.dataPath + "/Texts/O igri.docx";
        Application.OpenURL(path);
    }

    public void howToPlay()
    {
        Debug.Log(Application.dataPath);
        string path = Application.dataPath + "/Texts/CILJ IGRE.docx";
        Application.OpenURL(path);
    }
		
}