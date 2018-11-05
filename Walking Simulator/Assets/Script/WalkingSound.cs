using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSound : MonoBehaviour {
	
	// set variable for footstep
	private GameObject FootStep;
	private AudioSource Footy;
	private Vector3 OldLocation;

	// Use this for initialization
	void Start ()
	{
		FootStep = GameObject.Find("FootStepSound");
		Footy = FootStep.GetComponent<AudioSource>();
		OldLocation = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
		{
			if (Footy.isPlaying == false)
			{
				if (gameObject.transform.position != OldLocation)
				{
					Footy.Play();
				}
			}
		}
		OldLocation = gameObject.transform.position;

	}
}
