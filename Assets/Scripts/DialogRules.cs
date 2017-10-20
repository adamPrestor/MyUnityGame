using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogRules : MonoBehaviour, IHasChanged
{
    Dropping[] drops;
    public CanvasGroup cg;

    public void Start()
    {
         drops = GameObject.FindObjectsOfType<Dropping>();
    }

    public void HasChanged()
    {
        int pravilnih = 0;
        for(int i = 0; i< drops.Length; i++)
        {
            if(drops[i].transform.childCount > 0 && !drops[i].inventory)
            {
                if (checkIfCorrect(drops[i].transform.name, drops[i].transform.GetChild(0).name))
                {
                    Debug.Log(drops[i].transform.name + " je pravilen.");
                    pravilnih++;
                }
            }
        }

        if(pravilnih == 4)
        {
            Hide_test.show_selected(cg);
        }

    }

    bool checkIfCorrect(string dropName, string textField)
    {
        switch(dropName)
        {
            case "Panel1":
                return textField.Equals("Dialog1");
            case "Panel2":
                return textField.Equals("Dialog2");
            case "Panel3":
                return textField.Equals("Dialog3");
            case "Panel4":
                return textField.Equals("Dialog4");
            default:
                return true;

        }

    }

}
