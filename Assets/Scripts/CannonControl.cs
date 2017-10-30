using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonControl : MonoBehaviour {

    public Image cannon;
    public Transform slot;
    public CanvasGroup cg;
    public CanvasGroup cg1;
    public Text Instructions;

    private int Rotation = 0;

    public void CannonTurn()
    {      
        RectTransform rectTransform = cannon.GetComponent<RectTransform>();
        rectTransform.Rotate(new Vector3(0, 0, 45));
        Rotation = (Rotation + 1) % 8;
    }

    public void CannonFire()
    {
        if (Rotation == 7 && slot.childCount > 0)
        {
            Hide_test.show_selected(cg);
            Hide_test.show_selected(cg1);
            Instructions.text = "Začela se je 1. svetovna vojna.";
        }
        else
        {
            Hide_test.hide_selected(cg);
            Hide_test.hide_selected(cg1);
            Instructions.text = "Z miško pripelji v Avstrijo top, ga usmeri na Srbijo in pritisni na sprožilec.";
        }
            
    }
        
	
}
