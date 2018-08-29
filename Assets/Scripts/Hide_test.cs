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

    public bool startWithDialog = false;
    public string[] dialogGivers;
    public string[] dialogTexts;

    // Use this for initialization
    void Start()
    {
        hide();

        print(SceneManager.GetActiveScene().buildIndex);

        if(startWithDialog)
        {
            for(int i = 0; i<dialogGivers.Length; i++)
            {
                requestDialog(dialogGivers[i], dialogTexts[i]);
            }
        }

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
        cg.interactable = false;
    }

    public static void show_selected(CanvasGroup cg)
    {
        cg.alpha = 1.0f;
        cg.blocksRaycasts = true;
        cg.interactable = true;
    }

    public static void show_selected_dialog(CanvasGroup cg)
    {
        cg.alpha = 1.0f;
        cg.blocksRaycasts = false;
        cg.interactable = true;
    }

    public void show(CanvasGroup cg)
    {
        show_selected(cg);
    }

    public void hide_selected_nonStatic(CanvasGroup cg)
    {
        hide_selected(cg);
    }

    public void loadNextLevel()
    {
        SceneManager.LoadScene(VariableBase.LevelNumber);
    }

    public void loadNextLevelWithDelay(float time)
    {
        if (time == 0.0f)
            time = 3.0f;

        StartCoroutine(delayNextLevel(time));
    }

    public static void StaticLoadNextLevel()
    {
        SceneManager.LoadScene(VariableBase.LevelNumber);
    }

    public void requestDialog(string req, string msg)
    {
        dialogHandle.retrieveTextMsg(req, msg);
    }

    public void requestDialogJenko(string msg)
    {
        dialogHandle.retrieveTextMsg("Jenko", msg);
    }

    public void requestDialogTesla(string msg)
    {
        dialogHandle.retrieveTextMsg("Tesla", msg);
    }

    public void requestDialogJozef(string msg)
    {
        dialogHandle.retrieveTextMsg("Jozef", msg);
    }

    public void requestDialogCankar(string msg)
    {
        dialogHandle.retrieveTextMsg("Cankar", msg);
    }

    public void showAndHide(CanvasGroup cg)
    {
        cgg.Hide_All();

        //StopAllCoroutines();
        
        StartCoroutine(showAndHideProcedure(cg));
    }

    public void showHelpDialog(GameObject GO)
    {
        GO.SetActive(!GO.activeSelf);
    }

    IEnumerator showAndHideProcedure(CanvasGroup cg)
    {

        hide_selected(cg);
        yield return new WaitForSeconds(0.1f);
        show_selected(cg);
        yield return new WaitForSeconds(2f);
        hide_selected(cg);

    }

    IEnumerator delayNextLevel(float time)
    {
        yield return new WaitForSeconds(time);

        loadNextLevel();
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
