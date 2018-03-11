using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SimonsPictureLogic : MonoBehaviour, IHasChanged
{
    public CanvasGroup cg;

    public void HasChanged()
    {
        SceneManager.LoadScene(VariableBase.LevelNumber);
    }
}
