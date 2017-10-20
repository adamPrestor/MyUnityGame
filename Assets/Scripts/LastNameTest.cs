using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastNameTest : MonoBehaviour {

    public string[] correctAnswers;
    public Text answer;

    public CanvasGroup cg;
    
    private bool checkAnswer()
    {
        string text = answer.text;
        text = text.ToLower();

        for(int i = 0; i<correctAnswers.Length; i++)
            if(text.Equals(correctAnswers[i]))
                return true;
        return false;
    }

	public void editEnd()
    {
        if (checkAnswer())
            Hide_test.show_selected(cg);
    }
}
