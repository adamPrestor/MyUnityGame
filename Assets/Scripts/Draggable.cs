using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Transform passedParent = null;
    public Transform foster = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        passedParent = this.transform.parent;
        if (!foster)
            this.transform.SetParent(this.transform.parent.parent);
        else
            this.transform.SetParent(foster);

        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent( passedParent );
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
        ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
    }
}
