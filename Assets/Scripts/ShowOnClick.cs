using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowOnClick : MonoBehaviour, IPointerClickHandler
{

    public CanvasGroup cg;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (cg.alpha == 1.0f)
        {
            cg.alpha = 0;
            cg.interactable = false;
            cg.blocksRaycasts = false;
        }
        else
        {
            cg.alpha = 1.0f;
            cg.interactable = false;
            cg.blocksRaycasts = false;
        }
    }
}
