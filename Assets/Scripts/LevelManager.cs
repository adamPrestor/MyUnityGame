using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
	public Transform mainMenu, optionsMenu, optionsMenu2;
    public Object assetObject;
    public Sprite[] images;
    public Image imageTemp;

    public CanvasGroup text;

    int i = 1;

    public void LoadScene(int i){
        StartCoroutine(PlayGame());
	}

    IEnumerator PlayGame()
    {
        show_selected(text);
        yield return new WaitForSeconds(4.0f);
        hide_selected(text);
        SceneManager.LoadScene(i);
    }

    public static void hide_selected(CanvasGroup cg)
    {
        cg.alpha = 0.0f;
        cg.blocksRaycasts = false;
    }

    public static void show_selected(CanvasGroup cg)
    {
        cg.alpha = 1.0f;
        cg.blocksRaycasts = true;
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
        string path = "File://" + Application.dataPath + "/Texts/O IGRI.docx";
        Debug.Log(path);
        Application.OpenURL(path);
    }

    public void howToPlay()
    {
        Debug.Log(Application.dataPath);
        Debug.Log(Application.absoluteURL);
        string path = "File://" + Application.absoluteURL + "/Texts/O IGRI.docx";
        Debug.Log(path);
        Application.OpenURL(path);
    }

    public void turnThePage()
    {

        imageTemp.sprite = images[i];

        i = (i + 1) % 3;
    }
		
}