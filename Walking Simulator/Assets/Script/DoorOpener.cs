using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour {

	//set var float to be Degree of Circling
	public float DlDegree;
	public float DrDegree;
	
	//get object DoorLeft and DoorRight
	GameObject DoorLeft;
	GameObject DoorRight;
	
	//set var boolean for checking collision stay
	private Boolean TouchingDoor;
	
	// Use this for initialization
	void Start ()
	{
		DoorLeft = GameObject.Find("DoorLeft");
		DoorRight = GameObject.Find("DoorRight");
		TouchingDoor = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (TouchingDoor == true)
		{
			if (Input.GetMouseButtonDown(0))
			{
				DoorLeft.transform.Rotate(0, DlDegree, 0);
				DoorRight.transform.Rotate(0, DrDegree, 0);
				print("I dont understand");
			}
		}
	}
	
	// Collision is called when happen
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name.Equals("ForInteraction"))
		{
			TouchingDoor = true;
		}
	}
	
	// Collision is called when exit from colliding
	void OnCollisionExit (Collision col)
	{
		if (col.gameObject.name.Equals("ForInteraction"))
		{
			TouchingDoor = false;
		}
	}
}
