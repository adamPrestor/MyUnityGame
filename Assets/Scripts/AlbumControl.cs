using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class AlbumControl : MonoBehaviour, IPointerClickHandler
{

    public bool open;
    public GameObject GO;

    public void OnPointerClick(PointerEventData eventData)
    {
        GO.SetActive(open);
    }
}
