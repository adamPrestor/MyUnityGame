using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TracksLogic : MonoBehaviour {

    public int[] rotations;
    public CanvasGroup cg;
 

    private void Start()
    {
        rotations = new int[5];
        for(int i = 0; i<rotations.Length; i++)
        {
            rotations[i] = 1;
        }
    }

    public void changeRotations(int i, int r)
    {
        rotations[i] = r;
        isFinished();
    }

    public void isFinished()
    {
        if (checkTracks())
            Hide_test.show_selected(cg);
        else
            Hide_test.hide_selected(cg);
    }

    public bool checkTracks()
    {
        for (int i = 0; i<rotations.Length; i++)
        {
            if (rotations[i] != 0)
                return false;
        }
        return true;
    }
	
}
