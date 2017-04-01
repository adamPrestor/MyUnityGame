using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hide_test : MonoBehaviour {

    public CanvasGroup next_button;
    public CanvasGroup dialogs;
    public int levelToLoad;
    public DialogTextHandler dialogHandle;

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

    public void loadNextLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void requestDialog(string req, string msg)
    {
        dialogHandle.retrieveTextMsg(req, msg);
    }

}
