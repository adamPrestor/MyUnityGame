using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class FlightSimulator : MonoBehaviour
{

    private float dropingSpeed = 5.81f;
    public float force = 25.8f;
    public CanvasGroup cg;

    private Vector3 speed;
    private bool isMoving = true;
    private Vector3 startingPosition;
    private Quaternion startingRotation;

    private void Start()
    {
        startingPosition = this.transform.position;
        startingRotation = this.transform.rotation;
    }

    // Update is called once per frame
    void Update () {

        if (isMoving)
        {

            speed = this.GetComponent<Rigidbody>().velocity;

            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, -dropingSpeed, 0));
            //this.GetComponent<Rigidbody>().useGravity = true;

            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
            {
                this.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, force, 0.0f));
            }
        }

	}

    private void OnCollisionEnter(Collision collision)
    {
        isMoving = false;

        if (speed.y > -5.0f)
            Hide_test.show_selected(cg);
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
            
    }

}
