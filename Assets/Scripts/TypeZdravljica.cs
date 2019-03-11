using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeZdravljica : MonoBehaviour {

    public float waitTime;
    public int[] stop;
    int stopAt;
    int i = 0;

    public Choice[] choices;

    string zdravljicaText =
        "Žive naj vsi narodi,\n" +
        "ki hrepene dočakat dan,\n" +
        "da koder sonce hodi\n" +
        "prepir iz sveta bo pregnan,\n" +
        "da rojak\n" +
        "prost bo vsak\n" +
        "ne vrag, le sosed bo mejak!";

    public Text textArea;

    public Button choice1;
    public Button choice2;
    public Text choice1Text;
    public Text choice2Text;
    public CanvasGroup cg;

    bool contin = true;

    private Color c_success = new Color32(124, 255, 6, 255);
    private Color c_error = new Color32(255, 169, 21, 255);
    private Color c_default = new Color32(255, 255, 255, 255);


    // Use this for initialization
    void Start () {

        StartCoroutine(Typer());

	}

    bool IsStop(int i)
    {
        for(int j = 0; j<stop.Length; j++)
        {
            if(i == stop[j])
            {
                stopAt = j;
                return true;
            }
        }
        return false;
    }
	
	IEnumerator Typer()
    {
        while(i < zdravljicaText.Length && contin)
        {
            Debug.Log(i + " at " + zdravljicaText[i]);
            if(IsStop(i))
            {
                contin = false;
                AskQuestion();
            }
            yield return new WaitForSeconds(waitTime);
            textArea.text = zdravljicaText.Substring(0, i+1);
            i++;
        }

        if (i == zdravljicaText.Length)
        {
            yield return new WaitForSeconds(2.0f);
            Hide_test.StaticLoadNextLevel();
        }
    }

    void AskQuestion()
    {
        choice1Text.text = choices[stopAt].Choice1;
        choice2Text.text = choices[stopAt].Choice2;
    }

    public void Choosen1()
    {
        Debug.Log("Here");
        //ce vprasanje se ni bilo zastavljeno, potem ne more odgovarjati
        if (contin)
            return;

        //dobi pravilnost odgovora
        bool gotIt = choices[stopAt].truth;

        //poklici funkcijo za spremembo barve
        StartCoroutine(ChangeColor(choice1, gotIt));

        //ob vrnitvi odgovora spustimo izpisovanje naprej
        contin = true;

        //tipkaj naprej zdravljico
        StartCoroutine(Typer());
    }

    public void Choosen2()
    {
        //ce vprasanje se ni bilo zastavljeno, potem ne more odgovarjati
        if (contin)
            return;

        //dobi pravilnost odgovora
        bool gotIt = !choices[stopAt].truth;

        //poklici funkcijo za spremembo barve
        StartCoroutine(ChangeColor(choice2, gotIt));

        //ob vrnitvi odgovora spustimo izpisovanje naprej
        contin = true;

        //tipkaj naprej zdravljico
        StartCoroutine(Typer());
    }

    IEnumerator ChangeColor(Button choice, bool gotIt)
    {
        if (gotIt)
            choice.image.color = c_success;
        else
            choice.image.color = c_error;

        yield return new WaitForSeconds(0.5f);

        choice.image.color = c_default;

    }

}
