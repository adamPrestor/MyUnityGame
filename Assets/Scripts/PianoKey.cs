using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoKey : MonoBehaviour {

	public void PlayNote(float offset)
    {
        GetComponent<AudioSource>().pitch = Mathf.Pow(2f, offset / 6.0f);
        GetComponent<AudioSource>().Play();
    }
}
