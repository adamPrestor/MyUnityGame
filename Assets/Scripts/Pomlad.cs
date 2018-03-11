using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pomlad : MonoBehaviour, IHasChanged {

    int flowUsed = 1;
    public Transform giver;
    public CanvasGroup cg;

    // Use this for initialization
    void Start()
    {
        HasChanged();
    }

    public void HasChanged()
    {
        int count = 0;
        Debug.Log(giver.childCount);

        // still havent used all the flowers
        if (flowUsed < 5)
        {
            // check if there's any flowers to pick up
            foreach(Transform child in giver)
            {
                if (child.gameObject.activeSelf)
                {
                    Debug.Log(child.gameObject.name);
                    count++;
                }
            }

            if (count == 0)
            {
                // increase the count of curr
                flowUsed++;

                // enable the next flower to pick up
                giver.GetChild(0).gameObject.SetActive(true);
            }
        }
        else
        {
            Hide_test.StaticLoadNextLevel();
        }

    }

}
