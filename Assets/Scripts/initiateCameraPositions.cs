using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initiateCameraPositions : MonoBehaviour {

    public Vector3[] positions;

	// Use this for initialization
	void Start () {
        VariableBase.initiatePositions(positions);
	}
	
}
