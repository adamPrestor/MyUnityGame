using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraPictureButton : MonoBehaviour, IPointerClickHandler
{

    public GameObject go;

    public void OnPointerClick(PointerEventData eventData)
    {
        go.GetComponent<CourserControl>().takeAnotherPicture();
    }
}
