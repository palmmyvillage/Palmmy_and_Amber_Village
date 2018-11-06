using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFadeIn : MonoBehaviour {

	// set var for audiosource
	private AudioSource DQTheme;
	
	// set fadeout speed
	public float SoundFadeOut;
	
	// Use this for initialization
	void Start ()
	{
		DQTheme = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		DQTheme.volume -= SoundFadeOut;

		if (DQTheme.volume < 0)
		{
			DQTheme.enabled = false;
		}
	}
}
