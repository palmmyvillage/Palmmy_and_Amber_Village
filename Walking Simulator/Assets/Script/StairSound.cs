using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairSound : MonoBehaviour {
		
	// set textfile
	public TextAsset CannotLeaveYet;
	public TextAsset CanLeaveNow;

	//set string for PlayerRigidBody Name
	public String PlayerFootRigidBody;
	
	//set var of soundeffect
	private AudioSource StairDownSound;

	//set var boolean for checking collision stay
	private Boolean TouchingStair;
	
	// Use this for initialization
	void Start ()
	{
		TouchingStair = false;
		StairDownSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (TouchingStair == true)
		{
			if (NameStorage.TalkToKing && NameStorage.GetSword && NameStorage.GetShield && NameStorage.GetMoney)
			{
				gameObject.GetComponent<StairDialogueManager>().StairDialogueFile = CanLeaveNow;
				gameObject.GetComponent<StairDialogueManager>().enabled = true;
				gameObject.GetComponent<StairCallForChoice>().enabled = true;
			}
			else
			{
				gameObject.GetComponent<StairDialogueManager>().StairDialogueFile = CannotLeaveYet;
				gameObject.GetComponent<StairDialogueManager>().enabled = true;
			}
				
				
			TouchingStair = false;
		}
	}
	
	// Collision is called when happen
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name.Equals(PlayerFootRigidBody))
		{
			TouchingStair = true;
		}
	}
	
	// Collision is called when exit from colliding
	void OnCollisionExit (Collision col)
	{
		if (col.gameObject.name.Equals(PlayerFootRigidBody))
		{
			TouchingStair = false;
		}
	}
}
