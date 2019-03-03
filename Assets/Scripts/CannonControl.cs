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
    public DialogTextHandler DTH;

    private int Rotation = 0;
    private bool Solved = false;

    public void CannonTurn()
    {
        if (!Solved)
        {
            RectTransform rectTransform = cannon.GetComponent<RectTransform>();
            rectTransform.Rotate(new Vector3(0, 0, 45));
            Rotation = (Rotation + 1) % 8;
        }
    }

    public void CannonFire()
    {
        if (Solved)
            return;
        if (Rotation == 7 && slot.childCount > 0)
        {
            Hide_test.show_selected(cg);
            Hide_test.show_selected(cg1);
            Instructions.text = "Začela se je 1. svetovna vojna.";
            Solved = true;
            SetDialogs();
        }
        else
        {
            Hide_test.hide_selected(cg);
            Hide_test.hide_selected(cg1);
            Instructions.text = "Z miško pripelji v Avstrijo top, ga usmeri na Srbijo in pritisni na sprožilec.";
        }
    }

    private void SetDialogs()
    {
        DTH.RetrieveTextMsgMul("Jozef", "Menda sem pomagal Evropo zapeljati v Veliko vojno, ki jo bodo poimenovali 1. svetovna vojna. ");
        DTH.RetrieveTextMsgMul("Tesla", "Tehnika bo zaradi tega zelo napredovala … ");
        DTH.RetrieveTextMsgMul("Cankar", "Človek pa bo obnemel …");
    }

}
