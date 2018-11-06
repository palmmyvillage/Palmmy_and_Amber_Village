using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStartUp : MonoBehaviour {
	
	// set Time
	private float time;
	
	// set CharacterController
	public CharacterController CharCon;
	
	// Use this for initialization
	void Start ()
	{
		time = 0;
		CharCon = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		time += Time.deltaTime;

		if (time >= 3)
		{
			CharCon.enabled = true;
			gameObject.GetComponent<MouseLook>().enabled = true;
			gameObject.GetComponent<CharacterStartUp>().enabled = false;
		}

	}
}
