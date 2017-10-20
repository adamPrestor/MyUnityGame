using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hide_test : MonoBehaviour {

    public CanvasGroup next_button;
    public CanvasGroup dialogs;
    public int levelToLoad;
    public DialogTextHandler dialogHandle;
    public CanvasGroupGroup cgg;

    // Use this for initialization
    void Start()
    {
        hide();
    }

    public void hide()
    {
        hide_selected(next_button);
        hide_selected(dialogs);
    }

    public static void hide_selected(CanvasGroup cg)
    {
        cg.alpha = 0.0f;
        cg.blocksRaycasts = false;
    }

    public static void show_selected(CanvasGroup cg)
    {
        cg.alpha = 1.0f;
        cg.blocksRaycasts = true;
    }

    public void show(CanvasGroup cg)
    {
        cg.alpha = 1.0f;
        cg.blocksRaycasts = true;
    }

    public void loadNextLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void requestDialog(string req, string msg)
    {
        dialogHandle.retrieveTextMsg(req, msg);
    }

    public void requestDialogJenko(string msg)
    {
        dialogHandle.retrieveTextMsg("Jenko", msg);
    }

    public void showAndHide(CanvasGroup cg)
    {
        cgg.Hide_All();

        //StopAllCoroutines();
        
        StartCoroutine(showAndHideProcedure(cg));
    }

    IEnumerator showAndHideProcedure(CanvasGroup cg)
    {

        hide_selected(cg);
        yield return new WaitForSeconds(0.1f);
        show_selected(cg);
        yield return new WaitForSeconds(2f);
        hide_selected(cg);

    }

    [System.Serializable]
    public class CanvasGroupGroup
    {
        public CanvasGroup[] cgs;

        public CanvasGroupGroup() { }

        public void Hide_All()
        {
            foreach (CanvasGroup cg in cgs)
            {
                Hide_test.hide_selected(cg);
            }
        }

    }


}
