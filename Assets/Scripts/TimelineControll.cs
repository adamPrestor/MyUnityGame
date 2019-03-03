using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TimelineControll : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<Animator>().SetBool("open", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<Animator>().SetBool("open", false);
    }
}
