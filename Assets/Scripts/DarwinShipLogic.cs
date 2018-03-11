using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarwinShipLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Hide_test>().loadNextLevelWithDelay(4.0f);
    }
	
	
}
