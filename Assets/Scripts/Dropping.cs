using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropping : MonoBehaviour, IDropHandler
{

    public bool inventory = false;

    void IDropHandler.OnDrop(PointerEventData eventData)
    {

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

        if(d != null)
        {
            if(this.transform.childCount == 0 || inventory)
            {
                d.passedParent = this.transform;
            }
        }

    }

}
    