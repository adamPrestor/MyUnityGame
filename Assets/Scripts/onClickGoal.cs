﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class onClickGoal : MonoBehaviour, IPointerClickHandler
{

    public CanvasGroup cg;
    public GameObject[] slots;
    public GameObject flower;

    private bool[] selected;
    public bool[] solution;

    private int maxSize = 250;
    private int minSize = 50;

    public void OnPointerClick(PointerEventData eventData)
    {
        int rights = 0;

        selected = new bool[solution.Length];

        for(int i = 0; i<solution.Length; i++)
        {
            selected[i] = slots[i].GetComponent<onClickSlot>().isSelected;
            slots[i].GetComponent<onClickSlot>().hardReset();
        }

        rights = isRight();
        resizeIt(rights);

        if (rights == solution.Length)
        {
            Hide_test.show_selected(cg);
        } else
        {
            Hide_test.hide_selected(cg);
        }
    }

    public int isRight()
    {
        int result = 0;
        for(int i = 0; i < solution.Length; i++)
        {
            if (solution[i] == selected[i])
                result++;
        }
        return result;
    }

    public void resizeIt(int rights)
    {
        int size = minSize + rights * (maxSize / solution.Length);

        flower.GetComponent<RectTransform>().sizeDelta = new Vector2(size, size);

    }
}
