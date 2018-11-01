using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGSong : MonoBehaviour {

	// set Footstep
	public AudioSource Footstep01;
	
	// set var for song
	private Boolean Walking;
	
	// set time
	private float time;

	// Use this for initialization
	void Start () {
		
		// Play song

		Walking = false;
		
		time = 0;

	}
	
	// Update is called once per frame
	void Update ()
	{	
		if (Input.GetKey("Vertical") || Input.GetKey("Horizontal"))
		{
			if (Footstep01.isPlaying == false)
			{
				Footstep01.Play();
			}
		}
	}
}
