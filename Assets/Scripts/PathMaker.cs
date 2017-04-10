using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathMaker : MonoBehaviour {

    public QuestionTree currQuestion;
    public QuestionTree[] treeSet;

    public Text presernovText;
    public Text answerA;
    public Text answerB;

    public CanvasGroup cg;

    // Use this for initialization
    void Start () {

        //postavi trenutno vprasanje na prvo
        currQuestion = treeSet[0];

        //povezi vprasanja med seboj, glede na izbiro
        treeSet[0].pathA = treeSet[1];
        treeSet[0].pathB = treeSet[0];
        treeSet[1].pathA = treeSet[2];
        treeSet[1].pathB = treeSet[1];
        treeSet[2].pathA = treeSet[2];
        treeSet[2].pathB = treeSet[3];
        treeSet[3].pathA = treeSet[4];
        treeSet[3].pathB = treeSet[3];
        treeSet[4].pathA = treeSet[4];
        treeSet[4].pathB = treeSet[5];
        treeSet[5].pathA = treeSet[5];
        treeSet[5].pathB = null;

        //tako, zdaj imas pripravljeno vse za zacetek igre;
        setDialogs(currQuestion);

    }
	
	void setDialogs(QuestionTree temp)
    {

        //nastavi dialoge glede na potek igre
        presernovText.text = temp.question;
        answerA.text = temp.choiceA;
        answerB.text = temp.choiceB;
    }



    //funkcija ki se klice ob izbiri odgovora A
    public void goPathA()
    {
        if (currQuestion == null)
            return;
        currQuestion = currQuestion.pathA;
        
        //ce trenutnega vprasanja ni pomeni, da smo prisli do konca, v nasprotnem primeru nadaljujemo z igro
        if(currQuestion == null)
            Hide_test.show_selected(cg);
        else
            setDialogs(currQuestion);
    }

    //funkcija ki se klice ob izbiri odgovora B
    public void goPathB()
    {
        if (currQuestion == null)
            return;
        currQuestion = currQuestion.pathB;
        //ce trenutnega vprasanja ni pomeni, da smo prisli do konca, v nasprotnem primeru nadaljujemo z igro
        if (currQuestion == null)
            Hide_test.show_selected(cg);
        else
            setDialogs(currQuestion);
    }
}
