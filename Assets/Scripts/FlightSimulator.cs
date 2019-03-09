using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class FlightSimulator : MonoBehaviour
{

    private float dropingSpeed = 5.81f;
    public float force = 25.8f;
    public CanvasGroup cg;
    public GameObject LevelManager;
    public Button restartButton;
    public GameObject AfterGame;
    public GameObject Background;

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
        if(this.transform.position.y < 435)
        {
            Vector3 tempPos = transform.localPosition;
            tempPos.y = 0.84f;
            transform.localPosition = tempPos;

            isMoving = false;
            if (speed.y > -4.0f)
            {
                tempPos = Background.transform.localPosition;
                tempPos.z = -0.3f;
                Background.transform.localPosition = tempPos;
                AfterGame.SetActive(true);

                LevelManager.GetComponent<Hide_test>().requestDialog("Instructions", "Zapelji letalo v kmečko skrinjo. Mogoče ga nekoč razstavijo na brniškem letališču …");
            }
            else
            {
                LevelManager.GetComponent<Hide_test>().requestDialogJenko("To se je zgodilo tudi Edvardu Rusjanu. Ravno v Beogradu. Ampak, {0} – ti polet lahko ponoviš, on ga ni več mogel …");

                restartButton.gameObject.SetActive(true);

            }

        }
    }
    
    public void Restart()
    {
        Vector3 tempPos = transform.localPosition;
        tempPos.y = 10;
        transform.localPosition = tempPos;
        LevelManager.GetComponent<Hide_test>().HideAllDialogs();

        restartButton.gameObject.SetActive(false);

        isMoving = true;
    }

}
