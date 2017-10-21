using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AlbumConstants
{

    private static int current_page = 0;
    private static int previous_page = 0;
    private static GameObject[] pages;
    private static GameObject previous;
    private static GameObject next;

    public static int page
    {
        get
        { return current_page; }
        set
        {
            previous_page = current_page;
            current_page = value;
        }
    }

    public static void setPages(GameObject[] template)
    {
        pages = template;
    }

    public static void setPrevious(GameObject template)
    {
        previous = template;
    }

    public static void setNext(GameObject template)
    {
        next = template;
    }

    public static void changePage()
    {
        pages[previous_page].SetActive(false);
        pages[current_page].SetActive(true);
        hideShowNextPrevious();
    }

    public static void hideShowNextPrevious()
    {

        next.SetActive(true);
        previous.SetActive(true);

        if (current_page == 0)
            previous.SetActive(false);
        else if (current_page == pages.Length - 1)
            next.SetActive(false);
    }

}
