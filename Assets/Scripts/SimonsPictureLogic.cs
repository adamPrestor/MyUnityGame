using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimonsPictureLogic : MonoBehaviour, IHasChanged
{
    public CanvasGroup cg;

    public void HasChanged()
    {
        Hide_test.show_selected(cg);
    }
}
