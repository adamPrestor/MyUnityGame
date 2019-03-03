using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TraditionalLogic : MonoBehaviour, IHasChanged {

    float flowUsed = 0;
    public Transform giver;
    public CanvasGroup cg;
    public Transform[] slots;
    
    private float MaxVolume = 1.0f;
    public AudioSource AudioSrc;

    // Use this for initialization
    void Start()
    {
        //HasChanged();
        //AudioSrc.Play();
    }

    public void HasChanged()
    {
        float correct = 0f;

        foreach (Transform slot in slots)
        {
            if (slot.childCount > 0 && slot.name == slot.GetChild(0).name)
            {
                Destroy(slot.GetChild(0).GetComponent<DragHandealer>());
                correct += 1.0f;
            }
        }

        Debug.Log("Correct:" + correct);

        if (correct > 0.0f && !AudioSrc.isPlaying)
            AudioSrc.Play();
        
        AudioSrc.volume = correct / (float)slots.Length;

        if (correct == slots.Length)
        {
            Hide_test.show_selected(cg);
            return;
        }

        if (correct > flowUsed)
        {
            // enable the next flower to pick up
            giver.GetChild(0).gameObject.SetActive(true);

            flowUsed = correct;
        }

    }
}
