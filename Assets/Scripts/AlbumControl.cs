using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class AlbumControl : MonoBehaviour
{
    public GameObject[] pages;
    public GameObject previous;
    public GameObject next;

    private void Start()
    {
        AlbumConstants.setPages(pages);
        AlbumConstants.setNext(next);
        AlbumConstants.setPrevious(previous);
    }

}