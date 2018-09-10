using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pomlad_1 : MonoBehaviour, IHasChanged
{

    int flowUsed = 0;
    public Transform giver;
    public CanvasGroup cg;
    public Transform[] slots;

    // Use this for initialization
    void Start()
    {
        HasChanged();
    }

    public void HasChanged()
    {
        int count = 0;
        int correct = 0;

        foreach (Transform slot in slots)
        {
            if(slot.childCount > 0 && slot.name == slot.GetChild(0).name)
            {
                Destroy(slot.GetChild(0).GetComponent<DragHandealer>());
                correct++;
            }
        }

        Debug.Log("Correct:" + correct);

        if (correct == slots.Length)
        {
            Hide_test.StaticLoadNextLevel();
            return;
        }

        if (correct > flowUsed)
        {
            // enable the next flower to pick up
            giver.GetChild(0).gameObject.SetActive(true);

            flowUsed = correct;
        }
    }

}
