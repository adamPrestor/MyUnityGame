using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
                Transform temp = slot.GetChild(0);
                Destroy(temp.GetComponent<DragHandealer>());
                Destroy(temp.GetComponent<ShowOnHover>());
                foreach(Transform textBG in temp)
                {
                    CanvasGroup cg = textBG.GetComponent<CanvasGroup>();
                    cg.alpha = 1.0f;
                    Debug.Log(textBG.name);
                    foreach(Transform txt in textBG)
                    {
                        Debug.Log(txt.name);
                        txt.GetComponent<Text>().text = "SLOVENCI";
                    }
                }

                correct += 1.0f;
            }
        }
        
        if (correct > 0.0f && !AudioSrc.isPlaying)
            AudioSrc.Play();
        
        AudioSrc.volume = correct / slots.Length;

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
