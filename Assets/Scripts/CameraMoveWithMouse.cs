using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveWithMouse : MonoBehaviour {

    public float moveSpeed = 2.0f;
    public Vector2 xLim;
    public Vector2 yLim;
    public Vector2 zLim;

    // Update is called once per frame
    void Update () {

        Vector3 pos = transform.position;
        
        if(VariableBase.isItIn())
        {
            float xMove = -Input.GetAxis("Mouse X");
            float yMove = -Input.GetAxis("Mouse Y");
            
            float scroll = Input.mouseScrollDelta.y;

            if (scroll > 0)
                pos.z += moveSpeed;
            else if (scroll < 0)
                pos.z -= moveSpeed;

            pos.x += xMove * moveSpeed;
            pos.y += yMove * moveSpeed;

            pos.x = Mathf.Clamp(pos.x, xLim.x, xLim.y);
            pos.y = Mathf.Clamp(pos.y, yLim.x, yLim.y);
            pos.z = Mathf.Clamp(pos.z, zLim.x, zLim.y);

            transform.position = pos;

        }
            

    }
}
