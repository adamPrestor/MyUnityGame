using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnJenkoDialog : MonoBehaviour {

    public Button[] buttons;
    public string[] dialogParts;
    public int[] rightAnswers;
    public GameObject manager;
    public CanvasGroup cg;

    private int index = 0;
    private bool moveOn = false;
    private bool clickable = false;

    private void Start()
    {
        dialogRunner();
    }

    private void dialogRunner()
    {
        if (index < dialogParts.Length-1)
        {
            manager.GetComponent<Hide_test>().requestDialogJenko(dialogParts[index]);
            clickable = true;
        }
        else
        {
            manager.GetComponent<Hide_test>().requestDialogJenko(dialogParts[index]);
            Hide_test.show_selected(cg);
        }
    }

    public void choiceMade(int a)
    {
        if(clickable)
        {
            if(a == rightAnswers[index])
            {
                // correct choice
                buttons[a].GetComponent<Image>().color = new Color32(0, 255, 0, 100);

            } else
            {
                // wrong choice
                buttons[a].GetComponent<Image>().color = new Color32(255, 0, 0, 100);
            }

            // hide button
            buttons[a].GetComponent<CanvasGroup>().alpha = 0;
            buttons[a].GetComponent<CanvasGroup>().blocksRaycasts = false;

            // move dialog further
            index++;

            // disable clicks until dialog is loaded
            clickable = false;

            // call dialogRunner
            dialogRunner();
        }
    }


}
