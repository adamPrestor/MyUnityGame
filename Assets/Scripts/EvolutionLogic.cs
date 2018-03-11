using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EvolutionLogic : MonoBehaviour, IHasChanged
{

    public Transform slots;
    public GameObject go;

    public void HasChanged()
    {
        if (Check())
            StartCoroutine(EndOfLevel());
    }

    public bool Check()
    {
        Transform temp;

        foreach (Transform slot in slots)
        {
            temp = slot.GetChild(0);
            if (temp.name != slot.name)
            {
                Debug.Log("Failed at " + slot.name + "with picture " + temp.name);
                return false;
            }
        }

        return true;
    }

    IEnumerator EndOfLevel()
    {
        go.GetComponent<Hide_test>().requestDialogJenko("Hm, me zanima, kaj od tega sta bila Adam in Eva? In zakaj, če smo vsi iz opice nastali, Nemci večvredni so postali ?");

        yield return new WaitForSeconds(5.0f);

        Hide_test.StaticLoadNextLevel();

    }
}
