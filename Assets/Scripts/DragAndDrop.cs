using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour {
		// Use this for initialization
	Vector3 initialPosition;

	void Start () {
		//initialPosition1 = initialPosition.position.Set(-397,249,0);
		initialPosition = gameObject.transform.position;
	}

	
	// Update is called once per frame
	void Update () {}

	
		public void Drag()
		{
			GameObject.Find("Image8").transform.position = Input.mousePosition;
//			print ("We are dragging mouse");
		}
	public void Drag2()
	{
		GameObject.Find ("Image3").transform.position = Input.mousePosition;
	}
	public void Drag3()
	{
		GameObject.Find ("Image2").transform.position = Input.mousePosition;
	}
	public void Drag4()
	{
		GameObject.Find ("Image6").transform.position = Input.mousePosition;
	}
	public void Drag4a()
	{
		GameObject.Find ("Image9").transform.position = Input.mousePosition;
	}
	public void Drag5()
	{
		GameObject.Find ("Image11").transform.position = Input.mousePosition;
	}

	public void Drag6()
	{
		GameObject.Find ("Image1").transform.position = Input.mousePosition;

	}
		public void Drag7()
	{
		GameObject.Find ("Image4").transform.position = Input.mousePosition;

	}
	public void Drag8()
	{
		GameObject.Find ("Image5").transform.position = Input.mousePosition;

	}
	public void Drag9()
	{
		GameObject.Find ("Image7").transform.position = Input.mousePosition;

	}
	public void Drag10()
	{
		GameObject.Find ("Image10").transform.position = Input.mousePosition;

	}
	public void Drop()
	{
		//for (int i = 1; i <= 5; i++) {
			GameObject ph1 = GameObject.Find ("PlaceHolder1");
			float distance = Vector3.Distance (GameObject.Find ("Image8").transform.position, ph1.transform.position);
		print ("distance" + distance);	
		if (distance < 50) {
				GameObject.Find ("Image8").transform.position = ph1.transform.position;

		if (ph1.tag == "Kranj_K") {
			GameObject.Find ("Image8").transform.position = ph1.transform.position;
		} else {
				GameObject.Find ("Image8").transform.position = initialPosition;
		}
	}
	else
	{
			GameObject.Find("Image8").transform.position = initialPosition;
		}}
	
	public void Drop2()
	{
		//for (int i = 1; i <= 5; i++) {
		GameObject ph2 = GameObject.Find ("PlaceHolder2");
		float distance = Vector3.Distance (GameObject.Find ("Image3").transform.position, ph2.transform.position);
		print ("distance" + distance);	
		if (distance < 50) {
			GameObject.Find ("Image3").transform.position = ph2.transform.position;

			if (ph2.tag == "Kranj_R") {
				GameObject.Find ("Image3").transform.position = ph2.transform.position;
			} else {
				GameObject.Find ("Image3").transform.position = initialPosition;
			}
		}
		else
		{
			GameObject.Find("Image3").transform.position = initialPosition;
		}}
	public void Drop3()
	{
		//for (int i = 1; i <= 5; i++) {
		GameObject ph1 = GameObject.Find ("PlaceHolder3");
		float distance = Vector3.Distance (GameObject.Find ("Image2").transform.position, ph1.transform.position);
		print ("distance" + distance);	
		if (distance < 50) {
			GameObject.Find ("Image2").transform.position = ph1.transform.position;

			if (ph1.tag == "Kranj_A") {
				GameObject.Find ("Image2").transform.position = ph1.transform.position;
			} else {
				GameObject.Find ("Image2").transform.position = initialPosition;
			}
		}
		else
		{
			GameObject.Find("Image2").transform.position = initialPosition;
		}}

	public void Drop4()
	{
		//for (int i = 1; i <= 5; i++) {
		GameObject ph1 = GameObject.Find ("PlaceHolder4");
		float distance = Vector3.Distance (GameObject.Find ("Image6").transform.position, ph1.transform.position);
		print ("distance" + distance);	
		if (distance < 50) {
			GameObject.Find ("Image6").transform.position = ph1.transform.position;

			if (ph1.tag == "Kranj_N") {
				GameObject.Find ("Image6").transform.position = ph1.transform.position;
			} else {
				GameObject.Find ("Image6").transform.position = initialPosition;
			}
		}
		else
		{
			GameObject.Find("Image6").transform.position = initialPosition;
		}}

	public void Drop4a()
	{
		//for (int i = 1; i <= 5; i++) {
		GameObject ph1 = GameObject.Find ("PlaceHolder4");
		float distance = Vector3.Distance (GameObject.Find ("Image9").transform.position, ph1.transform.position);
		print ("distance" + distance);	
		if (distance < 50) {
			GameObject.Find ("Image9").transform.position = ph1.transform.position;

			if (ph1.tag == "Kranj_N") {
				GameObject.Find ("Image9").transform.position = ph1.transform.position;
			} else {
				GameObject.Find ("Image9").transform.position = initialPosition;
			}
		}
		else
		{
			GameObject.Find("Image9").transform.position = initialPosition;
		}}

	public void Drop5()
	{
		//for (int i = 1; i <= 5; i++) {
		GameObject ph1 = GameObject.Find ("PlaceHolder5");
		float distance = Vector3.Distance (GameObject.Find ("Image11").transform.position, ph1.transform.position);
		print ("distance" + distance);	
		if (distance < 50) {
			GameObject.Find ("Image11").transform.position = ph1.transform.position;

			if (ph1.tag == "Kranj_J") {
				GameObject.Find ("Image11").transform.position = ph1.transform.position;
			} else {
				GameObject.Find ("Image11").transform.position = initialPosition;
			}
		}
		else
		{
			GameObject.Find("Image11").transform.position = initialPosition;
		}}

	public void Drop6()
	{
		//for (int i = 1; i <= 5; i++) {
		GameObject ph1 = GameObject.Find ("PlaceHolder1");
		float distance = Vector3.Distance (GameObject.Find ("Image10").transform.position, ph1.transform.position);
		print ("distance" + distance);	
		if (distance < 50) {
			GameObject.Find ("Image10").transform.position = ph1.transform.position;

			if (ph1.tag == "Kranj_J") {
				GameObject.Find ("Image10").transform.position = ph1.transform.position;
			} else {
				GameObject.Find ("Image10").transform.position = initialPosition;
			}
		}
		else
		{
			GameObject.Find("Image10").transform.position = initialPosition;
			print ("Žal s to črko ne bo šlo");
		}}
}
