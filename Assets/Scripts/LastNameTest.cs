using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastNameTest : MonoBehaviour {

    public string[] correctAnswers;
    public Text answer;

    public CanvasGroup cg;

    public void Start()
    {
        StartCoroutine(StartTheCountdown());
    }

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
            Hide_test.StaticLoadNextLevel();
    }

    IEnumerator StartTheCountdown()
    {
        yield return new WaitForSeconds(5.0f);

        this.GetComponent<Hide_test>().requestDialogJenko(VariableBase.PlayerName + ", to je priimek našega največjega pesnika!");

    }
}
