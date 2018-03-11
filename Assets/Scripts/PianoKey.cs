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

	public void PlayNote(int offset)
    {        
        clearAllColors();

        if (checkIfEnd())
            return;

        Color clr;

        if (checkIfCorrect((int) offset))
        {
            Debug.Log("Right");

            clr = Color.green;
            i++;

            checkIfEnd();

        }
        else
        {
            Debug.Log("Wrong");

            clr = Color.red;
            i = 0;

        }

        colorSelectedKey((int)offset, clr);

        Debug.Log(i);

        GetComponent<AudioSource>().clip = noteSounds[offset];
        GetComponent<AudioSource>().Play();

    }

    private bool checkIfCorrect(int offset)
    {
        return offset == notes[i];
    }

    private bool checkIfEnd()
    {
        if (i == notes.Length)
        {
            Hide_test.show_selected(cg);
            return true;
        }
            

        return false;
    }

    private void colorSelectedKey(int index, Color clr)
    {
        keys[index].color = clr;
    }

    private void clearAllColors()
    {
        foreach (Image key in keys)
        {
            key.color = Color.white;
        }
    }

}
