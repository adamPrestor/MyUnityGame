using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class onClickGoal : MonoBehaviour, IPointerClickHandler
{

    public CanvasGroup cg;
    public GameObject[] slots;

    private bool[] selected;
    public bool[] solution;

    public void OnPointerClick(PointerEventData eventData)
    {
        selected = new bool[solution.Length];

        for(int i = 0; i<solution.Length; i++)
        {
            selected[i] = slots[i].GetComponent<onClickSlot>().isSelected;
        }

        if(isRight())
        {
            Hide_test.show_selected(cg);
        } else
        {
            Hide_test.hide_selected(cg);
        }
    }

    public bool isRight()
    {
        for(int i = 0; i < solution.Length; i++)
        {
            if (solution[i] != selected[i])
                return false;
        }
        return true;
    }
}
