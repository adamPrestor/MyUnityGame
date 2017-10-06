using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class Slot : MonoBehaviour, IDropHandler {

    public bool multipleStorage = false;
    public bool hide = false;
    public int maxCapacity = 1;

    public GameObject item {
		get {
			if(transform.childCount>0){
				return transform.GetChild (0).gameObject;
			}
			return null;
		}
	}

    public bool checkCapacity()
    {
        return transform.childCount < this.maxCapacity;
    }


	public void OnDrop (PointerEventData eventData)
	{
        this.multipleStorage = checkCapacity();
		if (!item || this.multipleStorage) {
			DragHandealer.ItemBeingDragged.transform.SetParent (transform);
			ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject,null, (x,y) => x.HasChanged());
		}
        if(hide)
        {
            for(int i = 0; i<transform.childCount; i++)
            {
                Transform temp = transform.GetChild(i);
                temp.GetComponent<CanvasGroup>().alpha = 0;
                temp.GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }
	}


	
}
