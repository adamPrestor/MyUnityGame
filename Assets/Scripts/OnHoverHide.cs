using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHoverHide : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private float previousAlpha;

    public void OnPointerEnter(PointerEventData eventData)
    {
        previousAlpha = this.GetComponent<CanvasGroup>().alpha;
        this.GetComponent<CanvasGroup>().alpha = 0.0f;
        Debug.Log("Halllo!");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<CanvasGroup>().alpha = previousAlpha;
    }
}
