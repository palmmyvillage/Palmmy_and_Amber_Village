using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MageDialogue : MonoBehaviour {
	
	//set var to save Dialgoue Box
	public GameObject DialogueBox;
	
	//set var to store Text
	public Text theText;
	
	//set var to store Dialogue
	public TextAsset DialogueFile;
	public TextAsset DialogueFileInUse;
	
	public string[] DialogueLine;
	private String DialogueInUse;
	
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
	public float Typespeed;
	
	// set var for tressure chest sound case
	public Boolean SoundIsPlaying;
	
	// if Object is NPC, use this sound
	private AudioSource TalkingSound;
	
	// set var for first line to be scrolling
	private Boolean FirstTime;
	
	//set Var for Character Name if their is any mention
	private String CharName;
	
	//get BGM
	public GameObject BGMobject;
	
	
	
	
	// Use this for initialization
	void Start ()
	{	
		// set sound effect to take from AudioSource
		TalkingSound = GetComponent<AudioSource>();
		
		//set player to be PlayerContoller
		Player_Controller = FindObjectOfType<CharacterController>();
		
		//set Character Name base on what player name them
		CharName = NameStorage.CharacterName;
		//temporary
	}
	
	// Update is called once per frame
	void Update()
	{
		if (FirstTime == true)
		{
			DialogueInUse = DialogueLine[currentLine].Replace("[CharacterName]", CharName);
			DialogueLine[currentLine] = DialogueInUse;
			print(DialogueInUse);
			print(DialogueLine[currentLine]);
			StartCoroutine(TextScroll(DialogueLine[currentLine]));
			FirstTime = false;
		}

		//theText.text = DialogueLine[currentLine];

		// Check if its a treassure case and sound no end
		else
		{
			if (SoundIsPlaying == false)
			{
				// Check if Collision with player happen or not
				if (Input.GetMouseButtonDown(0))
				{

					if (isTyping == false)
					{
						//change line when mouse buttoon down (left)
						currentLine += 1;
						DialogueInUse = DialogueLine[currentLine].Replace("[CharacterName]", CharName);
						DialogueLine[currentLine] = DialogueInUse;
						print(DialogueInUse);

						// deactivate dialogue boz after finish dialogue
						if (currentLine > endAtLine)
						{

							gameObject.GetComponent<Animator>().enabled = true;
							BGMobject.GetComponent<SoundFadeIn>().enabled = true;

							DialogueBox.SetActive(false);
							gameObject.GetComponent<MageDialogue>().enabled = false;
							currentLine = newLine;
							print("yeay");
						}
						else
						{
							StartCoroutine(TextScroll(DialogueLine[currentLine]));
						}
					}
					else if (isTyping && !cancelTyping)
					{
						cancelTyping = true;
					}
				}

				if (currentLine > endAtLine)
				{
					gameObject.GetComponent<Animator>().enabled = true;
					BGMobject.GetComponent<SoundFadeIn>().enabled = true;
					
					DialogueBox.SetActive(false);
					gameObject.GetComponent<MageDialogue>().enabled = false;
					currentLine = newLine;
					print("yeay");
					
					
				}
			}
		}
	}

	// set funtion to play text one by one letter
	private IEnumerator TextScroll(String LineofText)
	{
		int letter = 0;
		theText.text = "";
		isTyping = true;
		cancelTyping = false;
		while (isTyping && !cancelTyping && (letter < LineofText.Length - 1))
		{
			theText.text += LineofText[letter];
			letter += 1;
			TalkingSound.Play();	
			yield return new WaitForSeconds(Typespeed);
		}
		theText.text = LineofText;
		isTyping = false;
		cancelTyping = false;
		FirstTime = false;
	}
	
	//set for when enable player no move
	private void OnEnable()
	{	
		// set firsttime to be true
		FirstTime = true;
		
		//player no move
		Player_Controller.enabled = false;
		Player.GetComponent<MouseLook>().enabled = false;

		DialogueFileInUse = DialogueFile;
		
		//set Dialogue to the file we want to use and split line
		if (DialogueFileInUse != null)
		{
			DialogueLine = (DialogueFileInUse.text.Split('\n'));
		}
				
		// set script to automatically set the end of line according to the length of text file
		if (endAtLine == 0)
		{
			endAtLine = DialogueLine.Length-1;
		}
		
		//DiablogueBox Come
		DialogueBox.SetActive(true);
	}
}