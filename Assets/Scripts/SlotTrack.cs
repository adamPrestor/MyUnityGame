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

    // Use this for initialization
    void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        this.Rotation = Random.Range(0, 100)%2;
        Debug.Log(Rotation);

        changeRotation();
    }

    private void changeRotation()
    {
        image.rectTransform.Rotate(new Vector3(0, 0, 90 * (prevRotation - Rotation)));
        GO.GetComponent<TracksLogic>().changeRotations(index, Rotation);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        this.prevRotation = this.Rotation;
        this.Rotation = (this.Rotation + 1) % 2;

        changeRotation();
    }
}
