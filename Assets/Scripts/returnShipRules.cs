using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class returnShipRules : MonoBehaviour
{
    public int wantedNumber = 3;
    public CanvasGroup cg;

    private void Update()
    {
        if(transform.childCount == 3)
        {
            Hide_test.show_selected(cg);
        } else
        {
            Hide_test.hide_selected(cg);
        }
    }

    // DODAJ SE DIALOGE!!!


}
