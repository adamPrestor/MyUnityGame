using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PhotoDropHandler : MonoBehaviour, IHasChanged
{
    public CanvasGroup cg;

    public void HasChanged()
    {
        Hide_test.show_selected(cg);
    }
}
