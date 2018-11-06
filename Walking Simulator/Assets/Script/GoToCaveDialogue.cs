using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToCaveDialogue : MonoBehaviour {
	
	//set var to save Dialgoue Box
	public GameObject GotoCaveBox;
	
	//set var to store Text
	public Text GotoCavePos;
	
	//set var to store Dialogue
	public TextAsset GotoCaveFile;
	public TextAsset GotoCaveFileInUse;
	
	public string[] GotoCaveLine;
	private string GotoCaveInUse;
	
	//set current and end line
	private int currentLine;
	private int endAtLine;
	
	//set controller so that when talk player staystill
	public CharacterController Player_Controller;
	//set player to find then to disable mouselook script
	public GameObject Player;
	
	// set var for typing
	private Boolean isTyping = false;
	private Boolean cancelTyping = false;
	public float Typespeed;
	
	// if Object is NPC, use this sound
	private AudioSource TalkingSound;
	
	// set var for first line to be scrolling
	private Boolean FirstTime;
	
	// in case need character name
	private string CharacterName;
	
	// set boolean to see if Quiz
	public int QuizLine;
	private Boolean WaitForAnswer;
	
	// Get Object of QuizeBox
	public GameObject QuizBox;
	
	// Get Choice to choose
	public Text Choice1Pos;
	public string Choice1Content;

	public Text Choice2Pos;
	public string Choice2Content;
	
	

	// Use this for initialization
	void Start () {
		
		// set sound effect to take from AudioSource
		TalkingSound = GetComponent<AudioSource>();
		
		//set player to be PlayerContoller
		Player_Controller = FindObjectOfType<CharacterController>();
		
		// set CharacterName
		CharacterName = NameStorage.CharacterName;
		
		// set Quiz to false
		WaitForAnswer = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (FirstTime == true)
		{
			GotoCaveInUse = GotoCaveLine[currentLine].Replace("[CharacterName]", CharacterName);
			GotoCaveLine[currentLine] = GotoCaveInUse;
			StartCoroutine(TextScroll(GotoCaveLine[currentLine]));
			FirstTime = false;
		}

		else
		{
			if (WaitForAnswer == false)
			{
				// Check if Collision with player happen or not
				if (Input.GetMouseButtonDown(0))
				{

					if (isTyping == false)
					{
						//change line when mouse buttoon down (left)
						currentLine += 1;
						GotoCaveInUse = GotoCaveLine[currentLine].Replace("[CharacterName]", CharacterName);
						GotoCaveLine[currentLine] = GotoCaveInUse;

						// deactivate dialogue boz after finish dialogue
						if (currentLine > endAtLine)
						{
							Player_Controller.enabled = true;
							Player.GetComponent<MouseLook>().enabled = true;

							GotoCaveBox.SetActive(false);
							gameObject.GetComponent<StairDialogueManager>().enabled = false;
							currentLine = 0;
						}
						else
						{
							StartCoroutine(TextScroll(GotoCaveLine[currentLine]));
						}
					}
					else if (isTyping && !cancelTyping)
					{
						cancelTyping = true;
					}
				}

				if (currentLine > endAtLine)
				{
					Player_Controller.enabled = true;
					Player.GetComponent<MouseLook>().enabled = true;

					GotoCaveBox.SetActive(false);
					gameObject.GetComponent<StairDialogueManager>().enabled = false;
					currentLine = 0;
				}
			}
		}
		
	}
	
	
	// set funtion to play text one by one letter
	private IEnumerator TextScroll(String LineofText)
	{
		int letter = 0;
		GotoCavePos.text = "";
		isTyping = true;
		cancelTyping = false;
		while (isTyping && !cancelTyping && (letter < LineofText.Length - 1))
		{
			GotoCavePos.text += LineofText[letter];
			letter += 1;
			TalkingSound.Play();	
			yield return new WaitForSeconds(Typespeed);
		}
		GotoCavePos.text = LineofText;
		isTyping = false;
		cancelTyping = false;
		FirstTime = false;

		if (currentLine == QuizLine)
		{
			QuizBox.SetActive(true);
			WaitForAnswer = true;
			print(WaitForAnswer);
		}
	}
	
	//set for when enable player no move
	private void OnEnable()
	{	
		// set firsttime to be true
		FirstTime = true;
		
		//player no move
		Player_Controller.enabled = false;
		Player.GetComponent<MouseLook>().enabled = false;

		GotoCaveFileInUse = GotoCaveFile;
		
		//set Dialogue to the file we want to use and split line
		if (GotoCaveFileInUse != null)
		{
			GotoCaveLine = (GotoCaveFileInUse.text.Split('\n'));
		}
				
		// set script to automatically set the end of line according to the length of text file
		if (endAtLine == 0)
		{
			endAtLine = GotoCaveLine.Length-1;
		}
		
		//DiablogueBox Come
		GotoCaveBox.SetActive(true);
		
		WaitForAnswer = false;
		
		Choice1Pos.text = Choice1Content;
		Choice2Pos.text = Choice2Content;
	}
}
