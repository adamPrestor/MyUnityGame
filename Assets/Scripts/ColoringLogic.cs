using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColoringLogic : MonoBehaviour, IHasChanged {

    public Transform giver;
    public CanvasGroup cg;
    public GameObject[] slots;
    public Image map;
    public Sprite[] map_images;

    public Text InstructionText;
    public string[] instructions;

    int flowUsed = 0;

    // Use this for initialization
    void Start () {
        SetActiveSlots();
        SetImage();
        SetInstructions();
    }

    void SetActiveSlots()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i == flowUsed)
                slots[i].SetActive(true);
            else
                slots[i].SetActive(false);
        }
    }

    void SetImage()
    {
        map.sprite = map_images[flowUsed];
    }

    void SetInstructions()
    {
        if (flowUsed < instructions.Length)
            InstructionText.text = instructions[flowUsed];
    }

    public void HasChanged()
    {
        int correct = 0;

        foreach (GameObject slot_temp in slots)
        {
            Transform slot = slot_temp.GetComponent<Transform>();
            if (slot.childCount > 0 && slot.name == slot.GetChild(0).name)
            {
                Destroy(slot.GetChild(0).GetComponent<DragHandealer>());
                correct++;
            }
        }

        if (correct == slots.Length)
        {
            Hide_test.show_selected(cg);

            flowUsed = correct;

            SetImage();
            SetActiveSlots();

            return;
        }

        if (correct > flowUsed)
        {
            // enable the next flower to pick up
            giver.GetChild(0).gameObject.SetActive(true);

            flowUsed = correct;

            SetImage();
            SetActiveSlots();
            SetInstructions();
        }
    }
}
