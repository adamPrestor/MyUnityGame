using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public string question;
    public string choiceA;
    public string choiceB;

    public bool CorrectA = false;

    public Question(string Q, string A, string B, bool CA = false)
    {
        question = Q;
        choiceA = A;
        choiceB = B;
    }
}

