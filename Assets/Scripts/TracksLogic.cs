using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TracksLogic : MonoBehaviour {

    public CanvasGroup cg;
    private SlotTrack[] slots;

    private void Start()
    {
        slots = Object.FindObjectsOfType<SlotTrack>();
    }

    public void IsFinished()
    {
        if (CheckTracks())
            Hide_test.show_selected(cg);
        else
            Hide_test.hide_selected(cg);
    }

    public bool CheckTracks()
    {
        if (slots == null)
            return false;

        for (int i = 0; i<slots.Length; i++)
        {
            if (! slots[i].CheckCorrect())
                return false;
        }
        return true;
    }
	
}
