using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PianoKey : MonoBehaviour {

    private int i = 0;
    public int[] notes;
    public Image[] keys;
    public AudioClip[] noteSounds;
    public CanvasGroup cg;
    public GameObject LevelManager;

    private bool finished = false;

    private Color c_correct = new Color32(124, 211, 6, 150);
    private Color c_incorrect = new Color32(231, 100, 5, 150);
    private Color c_neutral = new Color(255, 255, 255, 100);

    public void PlayNote(int offset)
    {        
        ClearAllColors();

        if (finished)
        {
            GetComponent<AudioSource>().clip = noteSounds[offset];
            GetComponent<AudioSource>().Play();
            return;
        }

        Color clr;

        if (CheckIfCorrect(offset))
        {
            clr = c_correct;
            i++;

            CheckIfEnd();

            LevelManager.GetComponent<Hide_test>().dialogHandle.hideAllDialogs();
        }
        else
        {
            clr = c_incorrect;
            i = 0;

            // Dialog, request to start over
            LevelManager.GetComponent<Hide_test>().requestDialogJenko("Ta ton mi ni najbolj všeč. Poskusi znova od začetka.");
        }

        ColorSelectedKey(offset, clr);
        
        GetComponent<AudioSource>().clip = noteSounds[offset];
        GetComponent<AudioSource>().Play();

    }

    private bool CheckIfCorrect(int offset)
    {
        return offset == notes[i];
    }

    private bool CheckIfEnd()
    {
        if (i == notes.Length)
        {
            finished = true;
            Hide_test.show_selected(cg);
            return true;
        }
            

        return false;
    }

    private void ColorSelectedKey(int index, Color clr)
    {
        keys[index].color = clr;
    }

    private void ClearAllColors()
    {
        foreach (Image key in keys)
        {
            key.color = Color.white;
        }
    }

}
