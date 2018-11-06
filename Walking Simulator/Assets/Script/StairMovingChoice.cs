using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairMovingChoice : MonoBehaviour {

	public GameObject ChoiceBox;
	public GameObject StairDialogueBox;
	public GameObject StairObject;

	// set pos
	public float Xpos;
	public float Ypos;
	private RectTransform ChoiceRectTrans;

	// set status as Yes or No
	private Boolean Status;

	// set Ypos for both Choices
	public float YesPos;
	public float NoPos;
	
	// StairSound
	public GameObject StairSound;
	public AudioSource StairSoundSource;
	
	//set controller so that when talk player staystill
	public CharacterController Player_Controller;
	//set player to find then to disable mouselook script
	public GameObject Player;
	
	// set gameobject of blackPlane
	public GameObject BlackPlane;
	
	

	// Use this for initialization
	void Start()
	{
		//check for StairSound
		StairSoundSource = StairSound.GetComponent<AudioSource>();
		
		//set player to be PlayerContoller
		Player_Controller = FindObjectOfType<CharacterController>();
		
		Status = false;

		YesPos = 22.5f;
		NoPos = -23.5f;

		Xpos = gameObject.GetComponent<RectTransform>().anchoredPosition.x;
		Ypos = gameObject.GetComponent<RectTransform>().anchoredPosition.y;

		ChoiceRectTrans = gameObject.GetComponent<RectTransform>();
	}

	// Update is called once per frame
	void Update()
	{

		if (Status == true)
		{
			ChoiceRectTrans.localPosition = new Vector3(Xpos, YesPos, 0);

			// when press up or down
			if (Input.GetButtonDown("Vertical") && !Input.GetMouseButtonDown(0))
			{
				Status = false;
			}

			// when press enter
			if (!Input.GetButtonDown("Vertical"))
			{
				if (Input.GetMouseButtonDown(0))
				{
					
					StairSoundSource.Play();
					BlackPlane.SetActive(true);

					ChoiceBox.SetActive(false);
					StairDialogueBox.SetActive(false);
					StairObject.GetComponent<StairDialogueManager>().enabled = false;
					StairObject.GetComponent<StairCallForChoice>().enabled = false;
				}
			}
		}
		else
		{
			ChoiceRectTrans.localPosition = new Vector3(Xpos, NoPos, 0);
			// when press up or down
			if (Input.GetButtonDown("Vertical") && !Input.GetMouseButtonDown(0))
			{
				Status = true;
			}

			// when press enter
			if (!Input.GetButtonDown("Vertical"))
			{
				if (Input.GetMouseButtonDown(0))
				{
					ChoiceBox.SetActive(false);
					ChoiceBox.SetActive(false);
					StairDialogueBox.SetActive(false);
					StairObject.GetComponent<StairDialogueManager>().enabled = false;
					StairObject.GetComponent<StairCallForChoice>().enabled = false;
					
					Player_Controller.enabled = true;
					Player.GetComponent<MouseLook>().enabled = true;
				}
			}
		}

	}
}
