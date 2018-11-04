using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSound : MonoBehaviour {
	
	// set variable for footstep
	private GameObject FootStep;
	private AudioSource Footy;
	// private Vector3 

	// Use this for initialization
	void Start ()
	{
		FootStep = GameObject.Find("FootStepSound");
		Footy = FootStep.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButton("Vertical") && Footy.isPlaying == false)
		{
			print("Yeay");
			Footy.Play();
		}

	}
}
