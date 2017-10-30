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
            Go.GetComponent<Light>().intensity = 2.0f;
            Hide_test.show_selected(cg);
        }
        else
        {
            Go.GetComponent<Light>().intensity = 0.1f;
            Hide_test.hide_selected(cg);
        }
            
    }

}
