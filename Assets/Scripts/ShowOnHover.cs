using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public CanvasGroup cg;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hide_test.show_selected(cg);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hide_test.hide_selected(cg);
    }
}
