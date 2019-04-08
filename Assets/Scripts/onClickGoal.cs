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
    public Transform[] dropplets;
    public GameObject flower;

    private bool[] selected;
    public int[] solution;

    private int maxSize = 650;
    private int minSize = 100;

    private int positionYInitial = -100;

    public void OnPointerClick(PointerEventData eventData)
    {
        int rights = 0;

        selected = new bool[solution.Length];
        foreach(Transform child in transform)
        {
            int k = -1;
            int.TryParse(child.name.ToString(), out k);

            print(k);

            if (IsRight(k))
                rights++;
            else
                rights--;
                

        }

        print(rights);
        
        ResizeIt(rights);

        if (rights == solution.Length)
        {
            // success
            Hide_test.show_selected(cg);
        } else
        {
            // restart
            RestartGame();
            Hide_test.hide_selected(cg);
        }
    }

    public bool IsRight(int k)
    {
        for(int i = 0; i < solution.Length; i++)
        {
            if (solution[i] == k)
                return true;
        }
        return false;
    }

    public void RestartGame()
    {
        for(int i = 0; i<slots.Length; i++)
        {
            Hide_test.show_selected(dropplets[i].GetComponent<CanvasGroup>());
            dropplets[i].SetParent(slots[i].transform);
        }
    }

    public void ResizeIt(int rights)
    {
        int size = minSize + (rights + slots.Length - solution.Length) * (maxSize / slots.Length);

        print(size);
        print((maxSize / solution.Length));

        RectTransform temp = flower.GetComponent<RectTransform>();
        temp.sizeDelta = new Vector2(size, size);

        Vector3 position = temp.localPosition;
        position.y = positionYInitial + size / 2;
        temp.localPosition = position;

    }
}
