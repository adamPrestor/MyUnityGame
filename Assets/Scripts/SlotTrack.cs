using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotTrack : MonoBehaviour, IPointerClickHandler
{

    private int prevRotation = 0;
    private int Rotation = 0;
    public int index;
    public Image image;
    public GameObject GO;

    // For Track Logic purposes
    public int[] correctRotation = new int[1];
    public bool isImportant = false;

    // Use this for initialization
    void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        this.Rotation = Random.Range(0, 100)%2;

        ChangeRotation();
    }

    private void ChangeRotation()
    {
        image.rectTransform.Rotate(new Vector3(0, 0, 90 * (prevRotation - Rotation)));
        GO.GetComponent<TracksLogic>().IsFinished();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        this.prevRotation = this.Rotation;
        this.Rotation = (this.Rotation + 1) % 4;

        ChangeRotation();
    }

    public bool CheckCorrect()
    {
        if (isImportant)
        {
            for(int i = 0; i<correctRotation.Length; i++)
            {
                if (Rotation == correctRotation[i])
                {
                    return true;
                }
            }
            return false;
        }
        return true;
    }
}
