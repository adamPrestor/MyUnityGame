using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LetterToSrbia : MonoBehaviour {

    public string[] correctAnswers;
    public InputField inField;
    public Text LetterText;
    public CanvasGroup cg;
    public string[] answerReplacements;

    public bool requestDialog;
    public string JenkoText;
    public string FinalInputTextHolder = "";

    int i = 0;

    private string LetterString;

	// Use this for initialization
	void Start () {
        inField.Select();
        LetterString = LetterText.text;
	}

    public void EnterSolution()
    {
        if(i < correctAnswers.Length)
        {
            string temp = inField.text.ToLower();
            if(temp.Equals(correctAnswers[i].Trim().ToLower()))
            {
                LetterString = LetterString.Replace(answerReplacements[i], correctAnswers[i]);
                LetterText.text = LetterString;
                i++;
            }

            if(i < correctAnswers.Length)
            {
                inField.text = "";
                inField.placeholder.GetComponent<Text>().text = "Vnesi besedo na " + (i + 1) + ". mestu.";
                EventSystem.current.SetSelectedGameObject(inField.gameObject, null);
                inField.OnPointerClick(new PointerEventData(EventSystem.current));
            } else
            {
                inField.text = string.Empty;
                inField.placeholder.GetComponent<Text>().text = FinalInputTextHolder;
            }
        }

        CheckIfEnd();
    }

    void CheckIfEnd()
    {
        if(i == correctAnswers.Length)
        {
            inField.enabled = false;
            Hide_test.show_selected(cg);

            if(requestDialog)
                GameObject.Find("LevelManager").GetComponent<Hide_test>().requestDialogJenko(JenkoText);
        }
    }

}
