using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarwinShipLogic : MonoBehaviour {

    public Animator ship;
    public double timeZero;

	// Use this for initialization
	void Start () {
        ship.SetBool("Drive", true);

        timeZero = Time.time;
    }

    private void Update()
    {
        print(Time.time);
    }

}
