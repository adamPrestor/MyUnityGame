using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LandmarksLogic : MonoBehaviour, IHasChanged {

    public Transform giver;
    public CanvasGroup cg;
    public Text InstructionText;
    public DialogTextHandler dth;
    public AudioSource audioSrc;
    public Text MalhaText;

    public Transform[] slots;
    public string[] instructions;

    private int assignment = 0;
    private int maxAssignmet = 3;
    private int used = 0;

    public string[] JenkoDialogString;
    public string[] DialogGiver;
    public string[] DialogText;
    public string[] MalhaString;

    private string JenkoString = "Ampak uspehov nisem dosegel samo jaz, v tem času svet dobiva nov obraz:\n" +
                                 "Politične glave ustanavljajo nove države …";

    // Use this for initialization
    void Start () {
        SetInstructions();
        SetDialogs();
        SetAudio();
    }

    void SetAudio()
    {
        print((float)(assignment + 1.0f) / (maxAssignmet + 1));
        audioSrc.volume = (float)(assignment + 1.0f) / (maxAssignmet + 1);
    }

    void SetDialogs()
    {
        if (assignment < JenkoDialogString.Length)
            JenkoString += '\n' + JenkoDialogString[assignment];
        dth.retrieveTextMsg("Jenko", JenkoString);
        if (assignment < DialogGiver.Length)
            dth.RetrieveTextMsgMul(DialogGiver[assignment], DialogText[assignment]);
    }

    void SetInstructions()
    {
        if (assignment < instructions.Length)
            InstructionText.text = instructions[assignment];
        if (assignment < MalhaString.Length)
            MalhaText.text = MalhaString[assignment];
    }
    

    public void HasChanged()
    {
        int correct = 0;

        foreach(Transform slot in slots)
        {
            if (slot.childCount > 1)
            {
                slot.GetChild(0).gameObject.SetActive(false);
            } else
            {
                slot.GetChild(0).gameObject.SetActive(true);
            }

            if (slot.childCount > 1 && slot.name.Split('_')[0] == slot.GetChild(1).name)
            {
                Destroy(slot.GetChild(1).GetComponent<DragHandealer>());
                correct++;
            }
        }

        // incorporate assignment change
        if (correct >= (assignment + 1) * 3)
        {
            assignment++;
            SetInstructions();
            SetDialogs();
            SetAudio();
        }

        if (assignment >= maxAssignmet)
        {
            Hide_test.show_selected(cg);
            return;
        }

        if (correct > used)
        {
            giver.GetChild(0).gameObject.SetActive(true);

            used = correct;
        }
        
    }
}
