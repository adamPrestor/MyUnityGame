using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MartinQuiz : MonoBehaviour {

    public MartinQuestion temp;
    public QuizQuestions[] levels;
    
    int numQuestion = 0;
    int maxQuestion = 3;

    public Text questionText;
    public CanvasGroup cg;

    public Text textA;
    public Text textB;
    public Text textC;

    public Button buttonA;
    public Button buttonB;
    public Button buttonC;

    // Use this for initialization
    void Start () {
        loadQuestion();
	}

    //potrebujemo novo vprasanje!
    void loadQuestion()
    {
        if (numQuestion == maxQuestion)
        {
            Hide_test.show_selected(cg);
            return;
        }

        temp = levels[numQuestion].questions[Random.Range(0, levels[numQuestion].questions.Length)];
        questionText.text = temp.Question;
        textA.text = temp.AnswerA;
        textB.text = temp.AnswerB;
        textC.text = temp.AnswerC;
    }

    IEnumerator changeColor(Button choice, bool gotIt)
    {
        if (gotIt)
            choice.image.color = new Color32(0, 255, 0, 255);
        else
            choice.image.color = new Color32(255, 0, 0, 255);

        yield return new WaitForSeconds(0.5f);

        choice.image.color = new Color32(255, 255, 255, 255);

        //na koncu prestavimo stevec naprej in poklicemo novo vprasanje
        numQuestion++;
        loadQuestion();

    }

    //izberemo odgovor A
    public void choosenA()
    {
        //preveri, ce si prisel do zadnjega vprasanja!
        if (numQuestion == maxQuestion)
        {
            return;
        }

        //preverimo ce smo pravilno odgovorili
        bool gotIt = temp.truth == 0;

        StartCoroutine(changeColor(buttonA, gotIt));
              
    }

    //izberemo odgovor B
    public void choosenB()
    {
        //preveri, ce si prisel do zadnjega vprasanja!
        if (numQuestion == maxQuestion)
        {
            return;
        }

        //preverimo ce smo pravilno odgovorili
        bool gotIt = temp.truth == 1;

        StartCoroutine(changeColor(buttonB, gotIt));

    }

    //izberemo odgovor C
    public void choosenC()
    {
        //preveri, ce si prisel do zadnjega vprasanja!
        if (numQuestion == maxQuestion)
        {
            return;
        }
        //preverimo ce smo pravilno odgovorili
        bool gotIt = temp.truth == 2;

        StartCoroutine(changeColor(buttonC, gotIt));

    }

}



[System.Serializable]
public class QuizQuestions
{

    public MartinQuestion[] questions;

}
