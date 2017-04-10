using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionTree {

    public string question;
    public string choiceA;
    public string choiceB;
    public QuestionTree pathA;
    public QuestionTree pathB;

    /*public QuestionTree(string quest, string chA, string chB) {
        question = quest;
        choiceA = chA;
        choiceB = chB;
        pathA = null; pathB = null;
    }*/

}
