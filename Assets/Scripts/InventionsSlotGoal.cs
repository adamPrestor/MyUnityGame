using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventionsSlotGoal : MonoBehaviour, IHasChanged
{
    public InventorsLogic IL;

    public void HasChanged()
    {
        IL.IsDropped();
    }
}
