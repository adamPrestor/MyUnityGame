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
        "prepir iz sveta bo pregnan\n" +
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


    // Use this for initialization
    void Start () {

        StartCoroutine(Typer());

	}

    bool isStop(int i)
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
            if(isStop(i))
            {
                contin = false;
                askQuestion();
            }
            yield return new WaitForSeconds(waitTime);
            textArea.text = zdravljicaText.Substring(0, i+1);
            i++;
        }

        if(i == zdravljicaText.Length)
            Hide_test.show_selected(cg);
    }

    void askQuestion()
    {
        choice1Text.text = choices[stopAt].Choice1;
        choice2Text.text = choices[stopAt].Choice2;
    }

    public void choosen1()
    {
        //ce vprasanje se ni bilo zastavljeno, potem ne more odgovarjati
        if (contin)
            return;

        //dobi pravilnost odgovora
        bool gotIt = choices[stopAt].truth;

        //poklici funkcijo za spremembo barve
        StartCoroutine(changeColor(choice1, gotIt));

        //ob vrnitvi odgovora spustimo izpisovanje naprej
        contin = true;

        //tipkaj naprej zdravljico
        StartCoroutine(Typer());
    }

    public void choosen2()
    {
        //ce vprasanje se ni bilo zastavljeno, potem ne more odgovarjati
        if (contin)
            return;

        //dobi pravilnost odgovora
        bool gotIt = !choices[stopAt].truth;

        //poklici funkcijo za spremembo barve
        StartCoroutine(changeColor(choice2, gotIt));

        //ob vrnitvi odgovora spustimo izpisovanje naprej
        contin = true;

        //tipkaj naprej zdravljico
        StartCoroutine(Typer());
    }

    IEnumerator changeColor(Button choice, bool gotIt)
    {
        if(gotIt)
            choice.image.color = new Color32(0, 255, 0, 255);
        else
            choice.image.color = new Color32(255, 0, 0, 255);

        yield return new WaitForSeconds(0.5f);

        choice.image.color = new Color32(255, 255, 255, 255);

    }

}
