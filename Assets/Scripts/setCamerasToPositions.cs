using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setCamerasToPositions : MonoBehaviour {

    public GameObject[] cameras;

	// Use this for initialization
	void Start () {

		for(int i = 0; i<cameras.Length; i++)
        {
            Vector3 properties = VariableBase.getCameraPosition(i);
            Debug.Log(properties.z);

            cameras[i].transform.position = new Vector3(properties.x, properties.y, -38.5f);
            cameras[i].GetComponent<Camera>().orthographicSize = properties.z;

        }

	}
	
}
