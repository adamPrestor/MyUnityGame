using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollScript : MonoBehaviour, IScrollHandler {

    public Camera trans;

    public void OnScroll(PointerEventData eventData)
    {
        float change = eventData.scrollDelta.y;

        if (change > 0)
            trans.orthographicSize -= 0.1f;
        else
            trans.orthographicSize += 0.1f;
    }

}
