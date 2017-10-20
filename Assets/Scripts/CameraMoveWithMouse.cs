using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveWithMouse : MonoBehaviour {

    public float moveSpeed = 2.0f;
    public float zoomSpeed = 0.1f;
    public Vector2 xLim;
    public Vector2 yLim;
    public Vector2 zLim;
    public bool move = false;


    // Update is called once per frame
    void Update () {

        Vector3 pos = transform.position;
        
        if(move)
        {
            float xMove = Input.GetAxis("Mouse X");
            float yMove = Input.GetAxis("Mouse Y");
            float zMove = transform.GetComponent<Camera>().orthographicSize;
            
            float scroll = Input.mouseScrollDelta.y;

            if (scroll > 0)
                zMove -= zoomSpeed;
            else if (scroll < 0)
                zMove += zoomSpeed;

            pos.x += xMove * moveSpeed;
            pos.y += yMove * moveSpeed;

            pos.x = Mathf.Clamp(pos.x, xLim.x, xLim.y);
            pos.y = Mathf.Clamp(pos.y, yLim.x, yLim.y);
            zMove = Mathf.Clamp(zMove, zLim.x, zLim.y);

            transform.GetComponent<Camera>().orthographicSize = zMove;
            transform.position = pos;

        }
            

    }
}
