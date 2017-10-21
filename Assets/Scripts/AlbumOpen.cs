using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class AlbumOpen : MonoBehaviour, IPointerClickHandler
{

    public bool open;
    public bool openOrChange = true;
    public GameObject GO;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (openOrChange)
            GO.SetActive(open);
        else
        {
            if (open)
                AlbumConstants.page = AlbumConstants.page + 1;
            else
                AlbumConstants.page = AlbumConstants.page - 1;
        }

        AlbumConstants.changePage();

    }
}