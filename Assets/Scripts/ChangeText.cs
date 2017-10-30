using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour {

    public string[] lines;
    public float[] waitTime;
    public Text textArea;
    public CanvasGroup cg;
    public CanvasGroup cgBefore;
    public bool hideAfter = false;
    

	// Use this for initialization
	void Start () {
        StartCoroutine(changeText());
	}

    IEnumerator changeText()
    {
        for(int i = 0; i<lines.Length; i++)
        {
            textArea.text = lines[i];
            yield return new WaitForSeconds(waitTime[i]);
        }

        if (hideAfter)
            Hide_test.hide_selected(cgBefore);
        Hide_test.show_selected(cg);

    }

}
