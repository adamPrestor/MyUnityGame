using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CourserControl : MonoBehaviour
{

    private bool locked = true;
    private bool pictureTaken = false;

    public GameObject Controlled_Camera;
    public Hide_test hide_Test;
    public int cameraIndex;

    public string beforeClick = "";
    public string afterClick = "";


    private void Start()
    {
        UpdateText();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {
        if(!pictureTaken)
        {
            if (Input.GetMouseButton(0))
            {
                // proglasimo, da smo zajeli sliko
                pictureTaken = true;
                // ustavimo premikanje kamere
                Controlled_Camera.GetComponent<CameraMoveWithMouse>().move = false;
                // sprostimo cursor
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                
                // zapomnimo si koordinate kamere
                Vector3 position = Controlled_Camera.transform.position;
                float cameraSize = Controlled_Camera.GetComponent<Camera>().orthographicSize;
                VariableBase.setCameraPosition(cameraIndex, new Vector3(position.x, position.y, cameraSize));

                // posodobi navodila
                UpdateText();
            }
        }
	}

    public void takeAnotherPicture()
    {
        UpdateText();
        Controlled_Camera.GetComponent<CameraMoveWithMouse>().move = true;
        pictureTaken = false;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UpdateText()
    {
        if(pictureTaken)
            hide_Test.requestDialog("Instructions", afterClick);
        else
            hide_Test.requestDialog("Instructions", beforeClick);
    }
}
