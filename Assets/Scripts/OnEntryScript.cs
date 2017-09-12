using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnEntryScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

    public void OnPointerClick(PointerEventData eventData)
    {
        //Cursor.visible = !Cursor.visible;
        if(Cursor.lockState == CursorLockMode.None)
            
            Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        VariableBase.setIsIn(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        VariableBase.setIsIn(false);
        Cursor.visible = true;
    }

    private void Update()
    {
        if(VariableBase.isItIn())
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        Cursor.lockState = CursorLockMode.None;
    }

}
