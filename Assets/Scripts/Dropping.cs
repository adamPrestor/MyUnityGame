using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropping : MonoBehaviour, IDropHandler
{

    public bool inventory = false;
    public bool exchangeSlot = false;

    void IDropHandler.OnDrop(PointerEventData eventData)
    {

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

        if(d != null)
        {
            if(exchangeSlot && this.transform.childCount == 1)
            {
                Draggable d1 = this.transform.GetComponentInChildren<Draggable>();
                d1.passedParent = d.passedParent;
                d1.transform.SetParent(d1.passedParent);
                d.passedParent = this.transform;

            } else if(this.transform.childCount == 0 || inventory)
            {
                d.passedParent = this.transform;
            }
        }

    }

}
    