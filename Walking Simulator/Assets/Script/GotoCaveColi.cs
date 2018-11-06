using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoCaveColi : MonoBehaviour {
		

	//set var boolean for checking collision stay
	private Boolean GoingForwardToCave;
	
	//set string for PlayerRigidBody Name
	public String PlayerRigidBody;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (GoingForwardToCave == true)
		{
			gameObject.GetComponent<GoToCaveDialogue>().enabled = true;
			GoingForwardToCave = false;
			print("okay");
		}

	}
	
	// Collision is called when happen
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name.Equals(PlayerRigidBody))
		{
			GoingForwardToCave = true;
		}
	}
	
	// Collision is called when exit from colliding
	void OnCollisionExit (Collision col)
	{
		if (col.gameObject.name.Equals(PlayerRigidBody))
		{
			GoingForwardToCave = false;
		}
	}
}
