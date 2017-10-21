using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RadioControl : MonoBehaviour, IPointerClickHandler
{

    public CanvasGroup cg;

    public void OnPointerClick(PointerEventData eventData)
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();

        Hide_test.show_selected(cg);
    }
}
