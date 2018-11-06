using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {
		
	// set var for Time to run loop
	private float time;
	private int Timer;
	
	// set Boolean to check if StartGame
	private Boolean StartGame;
	
	// set var for Anime
	private Boolean Appear;
	
	// set PlainBlack
	public GameObject PlainBlack;
	
	// set MainLogo
	public GameObject MainLogo;
	
	// set Audio
	private AudioSource StartSound;

	// Use this for initialization
	void Start ()
	{
		StartGame = false;
		Appear = true;

		StartSound = gameObject.GetComponent<AudioSource>();

		Timer = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			StartGame = true;
			StartSound.Play();
		}

		if (StartGame == true)
		{
			MainLogo.GetComponent<SoundFadeIn>().enabled = true;
			time += Time.deltaTime;

			if (time >= 0.2f)
			{
				if (Appear == true)
				{
					gameObject.GetComponent<Text>().color = new Color(255, 255, 255, 0f);
					Appear = false;
					time = 0f;
					Timer += 1;
				}
				else
				{
					gameObject.GetComponent<Text>().color = new Color(255, 255, 255, 1f);
					Appear = true;
					time = 0f;
					Timer += 1;
				}
			}

			if (Timer >= 5)
			{
				PlainBlack.SetActive(true);
			}
		}
	}
}
