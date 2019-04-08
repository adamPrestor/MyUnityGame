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

    public GameObject[] placeHolders;

    private void Start()
    {
        if(AlbumConstants.ImageNumber < 0)
        {
            AlbumConstants.ImageNumber = placeHolders.Length;
            AlbumConstants.SetShown();
        }
        AlbumConstants.setPages(pages);
        AlbumConstants.setNext(next);
        AlbumConstants.setPrevious(previous);
        SetPlaceholderActivity();
    }

    public void ShowImage(int idx)
    {
        AlbumConstants.ChangeShown(idx);
        SetPlaceholderActivity();
    }

    public void SetPlaceholderActivity()
    {
        for (int i = 0; i < placeHolders.Length; i++)
        {
            placeHolders[i].SetActive(!AlbumConstants.Shown[i]);
        }
    }

}