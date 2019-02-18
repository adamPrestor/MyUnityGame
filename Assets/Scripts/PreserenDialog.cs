using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreserenDialog : MonoBehaviour {

    public string[] PunishmentExecutionair;
    public string[] PunishmentDelivered;
    private int PunishmentIndex = 0;

    private int QuestionIndex = 0;
    private Question CurrentQuestion;
    public Question[] DialogQuestions;

    public Text presernovText;
    public Text answerA;
    public Text answerB;

    public CanvasGroup cg;
    public GameObject levelManager;

    void Start()
    {
        QuestionIndex = 0;
        PunishmentIndex = 0;

        ChangeDialog();
    }

    void SetDialogs(Question temp)
    {
       //nastavi dialoge glede na potek igre
        presernovText.text = temp.question;
        answerA.text = temp.choiceA;
        answerB.text = temp.choiceB;
    }

    void ChangeDialog()
    {
        CurrentQuestion = DialogQuestions[QuestionIndex];
        SetDialogs(CurrentQuestion);
        QuestionIndex++;
    }

    void ExecutePunishment()
    {
        levelManager.GetComponent<Hide_test>().requestDialog(PunishmentExecutionair[PunishmentIndex], PunishmentDelivered[PunishmentIndex]);

        PunishmentIndex = (PunishmentIndex + 1) % PunishmentDelivered.Length;
    }

    public void ChooseA()
    {
        if (CurrentQuestion.CorrectA)
        {
            levelManager.GetComponent<Hide_test>().dialogHandle.hideAllDialogs();
            // check for question index out of bounds
            if (QuestionIndex >= DialogQuestions.Length)
                Hide_test.StaticLoadNextLevel();
            else
            {
                // continue
                ChangeDialog();
            }
        }
        else
        {
            // punish
            ExecutePunishment();
        }
    }

    public void ChooseB()
    {
        if (!CurrentQuestion.CorrectA)
        {
            levelManager.GetComponent<Hide_test>().dialogHandle.hideAllDialogs();
            // check for question index out of bounds
            if (QuestionIndex >= DialogQuestions.Length)
                Hide_test.StaticLoadNextLevel();
            else
            {
                // continue
                ChangeDialog();
            }
        }
        else
        {
            // punish
            ExecutePunishment();
        }
    }

}