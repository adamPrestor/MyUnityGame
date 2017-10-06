using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class onClickSlot : MonoBehaviour, IPointerClickHandler
{

    public bool isSelected = false;

    private Color isSelectedColor = new Color32(109, 109, 109, 100);
    private Color isNotSelectedColor = new Color32(255, 255, 255, 100);


    public void OnPointerClick(PointerEventData eventData)
    {

        this.isSelected = !this.isSelected;

        Debug.Log(this.isSelected);


        if(this.isSelected)
        {
            Debug.Log(this.isSelectedColor.r);
            transform.gameObject.GetComponent<Image>().color = new Color32(109, 109, 109, 100);
        } else
        {
            Debug.Log(this.isNotSelectedColor.r);
            transform.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
        }

    }

    public void hardReset()
    {
        this.isSelected = false;
        transform.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
    }
}
