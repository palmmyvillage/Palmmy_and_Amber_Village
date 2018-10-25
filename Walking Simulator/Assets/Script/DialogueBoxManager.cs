using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DialogueBoxManager : MonoBehaviour {
	
	//set var to save Dialgoue Box
	public GameObject DialogueBox;
	
	//set var to store Text
	public Text theText;
	
	//set var to store Dialogue
	public TextAsset DialogueFile;
	public string[] DialogueLine;
	
	//set current and end line
	public int currentLine;
	public int endAtLine;
	public int newLine;
	
	//set controller so that when talk player staystill
	public CharacterController Player_Controller;
	//set player to find then to disable mouselook script
	public GameObject Player;
	
	// set var for typing
	private Boolean isTyping = false;
	private Boolean cancelTyping = false;
	public float typespeed;
	
	// set var for tressure chest sound case
	public Boolean SoundIsPlaying;
	
	// if Object is NPC, use this sound
	private AudioSource TalkingSound;
	
	// Use this for initialization
	void Start ()
	{	
		// set sound effect to take from AudioSource
		TalkingSound = GetComponent<AudioSource>();
		
		//set Dialogue to the file we want to use and split line
		if (DialogueFile != null)
		{
			DialogueLine = (DialogueFile.text.Split('\n'));
		}
		
		//set player to be PlayerContoller
		Player_Controller = FindObjectOfType<CharacterController>();
				
		// set script to automatically set the end of line according to the length of text file
		if (endAtLine == 0)
		{
			endAtLine = DialogueLine.Length-1;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		theText.text = DialogueLine[currentLine];

		// Check if its a treassure case and sound no end
		if (SoundIsPlaying == false)
		{
			// Check if Collision with player happen or not
			if (Input.GetMouseButtonDown(0))
			{
				currentLine += 1;

				// if the object is NPC, play talking sound everytime press button
				if (gameObject.tag == "NPC")
				{
					TalkingSound.Play(0);
				}
				
				
				//if (isTyping == false)
				//{
				// change line when mouse buttoon down (left)
				//	currentLine += 1;

				// deactivate dialogue boz after finish dialogue
				//	if (currentLine > endAtLine)
				//	{
				//		Player_Controller.enabled = true;
				//		Player.GetComponent<MouseLook>().enabled = true;

				//		DialogueBox.SetActive(false);
				//		gameObject.GetComponent<DialogueBoxManager>().enabled = false;
				//		currentLine = newLine;
				//	}
				//	else
				//	{
				//		StartCoroutine(TextScroll(DialogueLine[currentLine]));
				//	}
				//}
				//else if (isTyping && !cancelTyping)
				//{
				//	cancelTyping = true;
				//}
			}

			if (currentLine > endAtLine)
			{
				Player_Controller.enabled = true;
				Player.GetComponent<MouseLook>().enabled = true;

				DialogueBox.SetActive(false);
				gameObject.GetComponent<DialogueBoxManager>().enabled = false;
				currentLine = newLine;

				// if the object is dialogue box then delete the colliderchecker
				if (gameObject.tag == "Tressure Box")
				{
					gameObject.GetComponent<CheckColforDia>().enabled = false;
				}
			}
		}

		// set funtion to play text one by one letter
	//private IEnumerator TextScroll(string LineofText)
	//{
	//	int letter = 0;
	//	theText.text = "";
	//	isTyping = true;
	//	cancelTyping = false;
	//	while (isTyping && !cancelTyping && (letter < LineofText.Length - 1))
	//	{
	//		theText.text += LineofText[letter];
	//		letter += 1;
	//		yield return new WaitForSeconds(typespeed);
	//	}
	//	theText.text = LineofText;
	//	isTyping = false;
	//	cancelTyping = false;
	}
	
	//set for when enable player no move
	private void OnEnable()
	{	
		//player no move
		Player_Controller.enabled = false;
		Player.GetComponent<MouseLook>().enabled = false;
		
		//DiablogueBox Come
		DialogueBox.SetActive(true);
		
		
	}

}
