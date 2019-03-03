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
    public int cameraIndex;
    public CanvasGroup cg;

    private void Start()
    {
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
                // prikazemo gumb za naprej
                Hide_test.show_selected(cg);

                // zapomnimo si koordinate kamere
                Vector3 position = Controlled_Camera.transform.position;
                float cameraSize = Controlled_Camera.GetComponent<Camera>().orthographicSize;
                VariableBase.setCameraPosition(cameraIndex, new Vector3(position.x, position.y, cameraSize));
                
            }
        }
	}

    public void takeAnotherPicture()
    {
        Controlled_Camera.GetComponent<CameraMoveWithMouse>().move = true;
        pictureTaken = false;
        Hide_test.hide_selected(cg);
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
