using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComplexDialogHandler : MonoBehaviour {

    public DialogPart[] parts;
    public float waitBetween = 1.0f;

    public void onStartDialog()
    {
        StartCoroutine(changeText());
    }

    IEnumerator changeText()
    {
        for(int k = 0; k<parts.Length;k++)
        {
            Debug.Log(parts[k].lines);
            for (int i = 0; i < parts[k].lines.Length; i++)
            {
                parts[k].textArea.text = VariableBase.InsertVariables(parts[k].lines[i]);
                yield return new WaitForSeconds(parts[k].waitTime[i]);
            }

            if (parts[k].hideAfter)
                Hide_test.hide_selected(parts[k].cgBefore);
            Hide_test.show_selected(parts[k].cgAfter);

            yield return new WaitForSeconds(waitBetween);

        }
    }

    public void PrintSomething()
    {
        print("Something.");
    }
}

[System.Serializable]
public class DialogPart
{
    public string[] lines;
    public float[] waitTime;
    public Text textArea;
    public CanvasGroup cgAfter;
    public CanvasGroup cgBefore;
    public bool hideAfter = false;
}
