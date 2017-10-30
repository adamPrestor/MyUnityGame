using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class returnShipRules : MonoBehaviour
{
    public int wantedNumber = 3;
    public CanvasGroup cg;
    public CanvasGroup cg1;

    public GameObject GO;

    private void Update()
    {
        if(transform.childCount == 3)
        {
            Hide_test.show_selected(cg);
            Hide_test.show_selected(cg1);

            GO.GetComponent<Hide_test>().requestDialogJenko("Jaz domov, kam pa vi?");
            
        } else
        {
            Hide_test.hide_selected(cg);
            Hide_test.hide_selected(cg1);
        }
    }

    // DODAJ SE DIALOGE!!!


}
