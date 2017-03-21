using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AnimatedDialog : MonoBehaviour {
	public Text TextArea;
	public string [] strings;
	public float speed = 0.1f;
	public delegate void ClickAction();
	public static event ClickAction OnClicked;
	public int levelToLoad;



	int stringIndex = 0;
	int characterIndex = 0;
	// Use this for initialization

	void Start () {
		StartCoroutine (DisplayTimer ());
			}
		IEnumerator DisplayTimer (){
		while (1 == 1) {
			yield return new WaitForSeconds (speed);
			if (characterIndex > strings [stringIndex].Length) {
				continue;
			}
			TextArea.text = strings [stringIndex].Substring (0, characterIndex);
			characterIndex++;
		}
	}

	// Update is called once per frame

				void OnGUI() {
					if (GUI.Button(new Rect(Screen.width / 2 - 50, 700, 100, 30), "Naprej"))
					{
		if(OnClicked !=null)
			OnClicked();
			if (characterIndex < strings [stringIndex].Length) {
				characterIndex = strings [stringIndex].Length;
			} else if (stringIndex < strings.Length) {
				stringIndex++;
				characterIndex = 0;
				SceneManager.LoadScene (levelToLoad);
			}
	}
}
}


