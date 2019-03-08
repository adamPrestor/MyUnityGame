using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorsLogic : MonoBehaviour {

    public Text edisonText, marconiText, bellText, ageText, inventionText;
    public GameObject LevelManager, InventionDialog, light;
    public CanvasGroup cg;
    public AudioSource srcAudio;

    public AudioClip[] clips;
    public GameObject[] inventions;
    public int[] age;

    private int assignment = 0;
    private int maxAssignment = 3;

    private string AgeString = "Starost:\n{0} let";

    private string[] Instructions = new string[2]
    {
        "Spravi izum v kmečko skrinjo, mogoče ti pride še prav.",
        "Davorin Jenko začasa svojega življenja ni bil priča le velikemu razvoju narodnih gibanj, ampak tudi razvoju industrije in mnogim izumom. Lahko bi spoznal ogromno različnih izumiteljev …\n\nKlikni na izumitelja, da bo naprava začela delovati."
    };

    private string[] InventionString = new string[]
    {
        "Sanjam, da bi nekega dne lahko naročil pico po telefonu. (Graham Bell)",
        "Vedno obstaja način, kako stvar narediti bolje. Poišči ga! (Thomas Alva Edison)",
        "Vsak dan človeštvo doseže več zmag v boju s prostorom in časom. (Guglielmo Marconi)"
    };

    private void LoadNextAssignment()
    {
        assignment++;
        if(assignment >= maxAssignment)
        {
            LevelManager.GetComponent<Hide_test>().requestDialogJenko("Naprej, naprej, naprej – avion, gramofon, avto, telefon – kaj vse to je treba imet`? Ni dovolj človeku le ubrano pet`?");
            Hide_test.show_selected(cg);
        } else
        {
            inventions[assignment - 1].SetActive(false);
            inventions[assignment].SetActive(true);
            LevelManager.GetComponent<Hide_test>().requestDialog("Instructions", Instructions[1]);
            ageText.text = string.Format(AgeString, age[assignment]);
        }
    }

    public void Pressed(int i)
    {
        if(assignment == i)
        {
            TurnInventionOn();
            LevelManager.GetComponent<Hide_test>().requestDialog("Instructions", Instructions[0]);
            inventions[assignment].AddComponent<DragHandealer>();
            inventionText.text = InventionString[assignment];
            InventionDialog.SetActive(true);
        }
        return;
    }

    private void TurnInventionOn()
    {
        switch(assignment)
        {
            case 0:
                srcAudio.clip = clips[0];
                srcAudio.Play();
                return;
            case 1:
                light.GetComponent<Light>().intensity = 2.0f;
                return;
            case 2:
                LevelManager.GetComponent<Hide_test>().requestDialogTesla("Tale izum bodo kasneje pripisali meni …");
                srcAudio.clip = clips[1];
                srcAudio.Play();
                return;
        }
        return;
    }

    public void IsDropped()
    {
        if (srcAudio.isPlaying)
            srcAudio.Stop();
        light.GetComponent<Light>().intensity = 0.1f;
        InventionDialog.SetActive(false);

        LoadNextAssignment();
    }
}
