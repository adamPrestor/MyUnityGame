using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MartinQuiz : MonoBehaviour {

    private MartinQuestion temp;
    public QuizQuestions[] levels;
    
    int numQuestion = 0;
    int maxQuestion = 3;

    int DifficultyLevel = 0;

    public Text questionText;

    public CanvasGroup cg;
    public CanvasGroup KrpanDialogCG;
    public CanvasGroup PortfolioCG;

    public Text textA;
    public Text textB;
    public Text textC;
    public Text textD;

    public Button[] buttons;

    public Image Obstacle;
    private Vector2 ObstacleDimensions;
    private Vector3 ObstaclePosition;

    void Start () {
        this.GetComponent<Hide_test>().requestDialogJenko("Koliko si star/a?");
        ObstaclePosition = Obstacle.GetComponent<RectTransform>().localPosition;
        ObstacleDimensions = Obstacle.GetComponent<RectTransform>().sizeDelta;
    }

    public void SetDifficulty(int difficulty)
    {
        DifficultyLevel = difficulty;
        this.GetComponent<Hide_test>().HideAllDialogs();
        LoadQuestion();
    }
    
    //potrebujemo novo vprasanje!
    void LoadQuestion()
    {
        if (numQuestion == maxQuestion)
        {
            Hide_test.show_selected(cg);
            Hide_test.hide_selected(PortfolioCG);
            return;
        }
        
        temp = levels[DifficultyLevel].questions[numQuestion];

        questionText.text = temp.Question;
        textA.text = temp.AnswerA;
        textB.text = temp.AnswerB;
        textC.text = temp.AnswerC;
        textD.text = temp.AnswerD;
    }

    IEnumerator ChangeColor(int choice, bool gotIt)
    {
        if (gotIt)
            buttons[choice].image.color = new Color32(0, 255, 0, 255);
        else
            buttons[choice].image.color = new Color32(255, 0, 0, 255);

        yield return new WaitForSeconds(0.5f);

        buttons[choice].image.color = new Color32(255, 255, 255, 255);

        if (gotIt)
        {
            //na koncu prestavimo stevec naprej in poklicemo novo vprasanje
            numQuestion++;
            LoadQuestion();
            RemoveObstacle();
            Hide_test.hide_selected(KrpanDialogCG);
        }
        else
        {
            Hide_test.show_selected(KrpanDialogCG);
        }

    }

    void RemoveObstacle()
    {
        float ObstacleHeight = (maxQuestion - numQuestion) * ObstacleDimensions.y / maxQuestion;
        Vector2 temp_dim = ObstacleDimensions;
        Vector3 temp_pos = ObstaclePosition;
        temp_dim.y = ObstacleHeight;
        temp_pos.y = (ObstacleHeight-ObstacleDimensions.y) / 2;
        Obstacle.GetComponent<RectTransform>().sizeDelta = temp_dim;
        Obstacle.GetComponent<RectTransform>().localPosition = temp_pos;
    }

    //izberemo odgovor
    // A - 0
    // B - 1
    // C - 2
    // D - 3
    public void GetAnswer(int answer)
    {
        //preveri, ce si prisel do zadnjega vprasanja!
        if (numQuestion == maxQuestion)
        {
            return;
        }

        //preverimo ce smo pravilno odgovorili
        bool gotIt = (temp.truth == answer);

        StartCoroutine(ChangeColor(answer, gotIt));
    }
}



[System.Serializable]
public class QuizQuestions
{

    public MartinQuestion[] questions;

}
