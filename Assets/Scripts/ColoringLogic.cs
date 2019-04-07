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
    public Text AgeText;
    public DialogTextHandler dth;

    public Text InstructionText;
    public string[] instructions;
    public int[] age;

    int flowUsed = 0;
    private string AgeString = "Starost:\n{0} let";

    private string JenkoString = "Ampak uspehov nisem dosegel samo jaz, v tem času svet dobiva nov obraz:\n" +
                                 "Politične glave ustanavljajo nove države …";

    // Use this for initialization
    void Start () {
        //SetActiveSlots();
        SetImage();
        SetInstructions();
        SetAge();
        SetDialogs();
    }

    void SetDialogs()
    {
        dth.RetrieveTextMsgMul("Jenko", JenkoString);
    }

    void SetActiveSlots()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i == flowUsed-1)
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

    void SetAge()
    {
        if (flowUsed < age.Length)
            AgeText.text = string.Format(AgeString, age[flowUsed]);
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
            SetAge();
        }
    }
}
