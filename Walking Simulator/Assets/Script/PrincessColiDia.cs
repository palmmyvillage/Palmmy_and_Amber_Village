﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessColiDia : MonoBehaviour {
		

	//set var boolean for checking collision stay
	private Boolean TalkToPrincess;
	
	//set gameobject of princess
	public GameObject PrincessObject;
	
	//set string for PlayerRigidBody Name
	public String PlayerRigidBody;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (TalkToPrincess == true)
		{
			PrincessObject.GetComponent<PrincessDiaBox>().enabled = true;
			TalkToPrincess = false;
			print("okay");
		}

	}
	
	// Collision is called when happen
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name.Equals(PlayerRigidBody))
		{
			TalkToPrincess = true;
		}
	}
	
	// Collision is called when exit from colliding
	void OnCollisionExit (Collision col)
	{
		if (col.gameObject.name.Equals(PlayerRigidBody))
		{
			TalkToPrincess = false;
		}
	}
}