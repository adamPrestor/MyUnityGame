using UnityEngine;
using System.Collections;

public class PredvajajSliko : MonoBehaviour {
	public Sprite slika1, slika2;


	float timer = 1f;
	float delay = 1f;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = slika1;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			if (this.gameObject.GetComponent<SpriteRenderer> ().sprite == slika1) {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = slika2;
				timer = delay;
				return;
			}
			if (this.gameObject.GetComponent<SpriteRenderer> ().sprite == slika2) {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = slika1;
				timer = delay;
				return;
			}
		}

	}
}
