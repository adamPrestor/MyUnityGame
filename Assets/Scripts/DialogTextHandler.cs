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


    public void retrieveText(string name)
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
                break;
        }
                
        StartCoroutine(showHide(cg_tmp, txt, msg, 3));
        
    }

    public void retrieveTextMsg(string name, string msg)
    {
        CanvasGroup cg_tmp = null;
        Text txt = null;

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
            default:
                Debug.Log("Shame");
                break;
        }

        StartCoroutine(showHide(cg_tmp, txt, msg, 3));
    }

    IEnumerator showHide(CanvasGroup cg, Text txt, string msg, int SecondsToWait)
    {
        txt.text = msg;
        Hide_test.show_selected(cg);

        yield return new WaitForSeconds(SecondsToWait);

        Hide_test.hide_selected(cg);
    }

}
