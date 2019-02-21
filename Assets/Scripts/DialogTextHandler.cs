using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

[System.Serializable]
public class DialogTextHandler : MonoBehaviour
{

    public string[] JozefText;
    public string[] TeslaText;
    public string[] CankarText;
    public string[] JenkoText;
    
    //premisli se 1x, ce bi naredil to tukaj.
    public CanvasGroup jozefDia;
    public CanvasGroup teslaDia;
    public CanvasGroup cankarDia;
    public CanvasGroup jenkoDia;

    public Text jozefText;
    public Text teslaText;
    public Text cankarText;
    public Text jenkoText;

    public Text instructions;

    public void RetrieveText(string name)
    {
        string msg = null;
        CanvasGroup cg_tmp = null;
        Text txt = null;
        
        switch (name)
        {
            case "Jozef":
                msg = JozefText[Random.Range(0, JozefText.Length)];
                cg_tmp = jozefDia;
                txt = jozefText;
                break;
            case "Tesla":
                msg = TeslaText[Random.Range(0, TeslaText.Length)];
                cg_tmp = teslaDia;
                txt = teslaText;
                break;
            case "Cankar":
                msg = CankarText[Random.Range(0, CankarText.Length)];
                cg_tmp = cankarDia;
                txt = cankarText;
                break;
            case "Jenko":
                msg = JenkoText[Random.Range(0, JenkoText.Length)];
                cg_tmp = jenkoDia;
                txt = jenkoText;
                break;
            default:
                Debug.Log("Shame");
                return;
        }
                
        showDialog(cg_tmp, txt, msg, true);
        
    }

    public void retrieveTextMsg(string name, string msg)
    {
        CanvasGroup cg_tmp = null;
        Text txt = null;

        // {0} - playerName
        msg = string.Format(msg, VariableBase.PlayerName);

        switch (name)
        {
            case "Jozef":
                cg_tmp = jozefDia;
                txt = jozefText;
                break;
            case "Tesla":
                cg_tmp = teslaDia;
                txt = teslaText;
                break;
            case "Cankar":
                cg_tmp = cankarDia;
                txt = cankarText;
                break;
            case "Jenko":
                cg_tmp = jenkoDia;
                txt = jenkoText;
                break;
            case "Instructions":
                instructions.text = msg;
                return;
            default:
                Debug.Log("Shame");
                break;
        }

        showDialog(cg_tmp, txt, msg, true);

    }

    public void hideAllDialogs()
    {
        Hide_test.hide_selected(jozefDia);
        Hide_test.hide_selected(teslaDia);
        Hide_test.hide_selected(cankarDia);
        Hide_test.hide_selected(jenkoDia);
    }

    public void showDialog(CanvasGroup cg, Text txt, string msg, bool theOnlyOne)
    {
        if (theOnlyOne)
            hideAllDialogs();

        txt.text = msg;
        Hide_test.show_selected_dialog(cg);
    }

    IEnumerator showHide(CanvasGroup cg, Text txt, string msg, int SecondsToWait)
    {
        txt.text = msg;
        Hide_test.show_selected(cg);

        yield return new WaitForSeconds(SecondsToWait);

        Hide_test.hide_selected(cg);
    }

}
