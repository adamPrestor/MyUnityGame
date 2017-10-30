using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LetterToSrbia : MonoBehaviour {

    public string[] correctAnswers;
    public InputField inField;
    public Text help;
    public CanvasGroup cg;
    int i = 0;

    public bool requestDialog;
    public string JenkoText;

	// Use this for initialization
	void Start () {
        inField.Select();
	}

    public void enterSolution()
    {
        if(i < correctAnswers.Length)
        {
            Debug.Log(inField.text.ToLower());
            string temp = inField.text.ToLower();
            if(temp.Equals(correctAnswers[i]))
            {
                i++;
            }
        }

        help.text = "Vnesi besedo na " + (i+1) + " mestu.";
        inField.text = "";
        inField.placeholder.GetComponent<Text>().text = "Vnesi besedo na " + (i + 1) + ". mestu.";
        EventSystem.current.SetSelectedGameObject(inField.gameObject, null);
        inField.OnPointerClick(new PointerEventData(EventSystem.current));

        checkIfEnd();
    }

    void checkIfEnd()
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
