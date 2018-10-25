using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColforDia : MonoBehaviour {
	
	//set string for PlayerRigidBody Name
	public String PlayerRigidBody;
	
	//set var boolean for checking collision stay
	public Boolean TouchingPlayer;
	
	// if Object is NPC, use this sound
	private AudioSource TalkingSound;
	
	// Use this for initialization
	void Start ()
	{
		// set sound effect to take from AudioSource
		TalkingSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		if (TouchingPlayer == true)
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (gameObject.tag == "NPC")
				{
					TalkingSound.Play(0);
				}
				gameObject.GetComponent<DialogueBoxManager>().enabled = true;
			}
		}
	}
	
	// Collision is called when happen
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name.Equals(PlayerRigidBody))
		{
			TouchingPlayer = true;
		}
	}
	
	// Collision is called when exit from colliding
	void OnCollisionExit (Collision col)
	{
		if (col.gameObject.name.Equals(PlayerRigidBody))
		{
			TouchingPlayer = false;
		}
	}
}
