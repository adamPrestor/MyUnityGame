using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LightBulbSwitch : MonoBehaviour, IPointerClickHandler
{

    bool turnOn = false;
    public GameObject Go;
    public CanvasGroup cg;

    public void OnPointerClick(PointerEventData eventData)
    {
        turnOn = !turnOn;
        handleSwitch();
    }

    private void handleSwitch()
    {
        if (turnOn)
        {
            Go.GetComponent<Image>().color = new Color32(255, 255, 0, 50);
            Hide_test.show_selected(cg);
        }
        else
        {
            Go.GetComponent<Image>().color = new Color32(255, 255, 0, 0);
            Hide_test.hide_selected(cg);
        }
            
    }

}
