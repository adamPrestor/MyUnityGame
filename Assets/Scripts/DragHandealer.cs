﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandealer : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public static GameObject ItemBeingDragged;
	Vector3 startPosition;
	Transform startParent;

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		ItemBeingDragged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		ItemBeingDragged = null;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		if (transform.parent == startParent) {
			transform.position = startPosition;
		}
	}

	#endregion




}