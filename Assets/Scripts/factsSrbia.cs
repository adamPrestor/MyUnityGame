using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class factsSrbia : MonoBehaviour {

    public Dropdown[] dropdowns;
    public int[] rightResult;
    public CanvasGroup cg;


	// Use this for initialization
	void Start () {
		for(int i = 0; i<dropdowns.Length; i++)
        {
            dropdowns[i].value = 0;
        }
	}

    public void checkResult()
    {
        for(int i = 0; i<dropdowns.Length; i++)
        {
            if(dropdowns[i].value == rightResult[i])
            {
                Debug.Log(i + " is right \n");
            } else
            {
                return;
            }
        }

        Hide_test.show_selected(cg);
        GameObject.Find("LevelManager").GetComponent<Hide_test>().requestDialogJenko("Ampak uspehov nisem dosegel samo jaz, v tem času svet dobiva nov obraz!");

    }
	
}
