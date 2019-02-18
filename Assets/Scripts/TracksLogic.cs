using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TracksLogic : MonoBehaviour, IPointerClickHandler {

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

        bool result = true;

        for (int i = 0; i<slots.Length; i++)
        {
            if (!slots[i].CheckCorrect())
                result = false;
        }
        return result;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        foreach (SlotTrack slot in slots)
        {
            slot.GetComponent<Image>().color = slot.c_neutral;
        }
    }
}
