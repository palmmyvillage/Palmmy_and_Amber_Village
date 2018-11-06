using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBoxForMenu : MonoBehaviour {

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
	
	// set var for typing
	private Boolean isTyping = false;
	private Boolean cancelTyping = false;
	public float Typespeed;
	
	// if Object is NPC, use this sound
	private AudioSource TalkingSound;
	
	// set var for first line to be scrolling
	private Boolean FirstTime;
	
	//set Var for Character Name if their is any mention
	public String CharName;
	
	// set var to store NamingLine
	private int ActivateNamingLine;
	
	// set var to freeze whole process
	public Boolean WaitForAnswer;
	
	//set second whiteplane
	public GameObject WhitePlane2;
	
	// set boolean for Getting the MovingChoices to appear
	public Boolean SetMovingChoiceActive;
	
	// set public for ChoiceBox;
	public GameObject ChoiceBox;
	
	
	
	
	// Use this for initialization
	void Start ()
	{	
		// set wait for answer
		WaitForAnswer = false;
		
		// set sound effect to take from AudioSource
		TalkingSound = GetComponent<AudioSource>();
		
		//set Character Name base on what player name them
		CharName = NameStorage.CharacterName;
		//temporary
		
		//set ActivateNamingLine Number
		ActivateNamingLine = gameObject.GetComponent<ActivateNaming>().NamingLine;
		
		//set SetMovingChoiceActive false
		SetMovingChoiceActive = false;
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
			// check to see if waiting or not
			if (WaitForAnswer == false)
			{
				// Check if Collision with player happen or not
				if (Input.GetMouseButtonDown(0))
				{
					print("Hoii");
					
					
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
							DialogueBox.SetActive(false);
							gameObject.GetComponent<DialogueBoxForMenu>().enabled = false;
							WhitePlane2.SetActive(true);
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
					DialogueBox.SetActive(false);
					gameObject.GetComponent<DialogueBoxForMenu>().enabled = false;
					WhitePlane2.SetActive(true);
				}
			}
		}
	}

	// set funtion to play text one by one letter
	public IEnumerator TextScroll(String LineofText)
	{
		int letter = 0;
		theText.text = "";
		isTyping = true;
		cancelTyping = false;
		gameObject.GetComponent<ActivateChoices>().Allow = false;
		print(gameObject.GetComponent<ActivateChoices>().Allow);
		while (isTyping && !cancelTyping && (letter < LineofText.Length - 1))
		{
			theText.text += LineofText[letter];
			letter += 1;
			if (gameObject.tag != "Tressure Box")
			{
				TalkingSound.Play();	
			}
			yield return new WaitForSeconds(Typespeed);
		}
		theText.text = LineofText;
		isTyping = false;
		cancelTyping = false;
		FirstTime = false;
		gameObject.GetComponent<ActivateChoices>().Allow = true;
		print(gameObject.GetComponent<ActivateChoices>().Allow);

		if (SetMovingChoiceActive == true)
		{
			SetMovingChoiceActive = false;
			ChoiceBox.SetActive(true);
		}
		
		if (currentLine == ActivateNamingLine)
		{
			WaitForAnswer = true;
		}
	}
	
	//set for when enable player no move
	private void OnEnable()
	{	
		// set firsttime to be true
		FirstTime = true;

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
		
		// set wait for answer
		WaitForAnswer = false;
	}
	
	// force coroutine
	public void ForceCoroutine()
	{
		CharName = NameStorage.CharacterName;
		DialogueInUse = DialogueLine[currentLine].Replace("[CharacterName]", CharName);
		DialogueLine[currentLine] = DialogueInUse;
		StartCoroutine(TextScroll(DialogueLine[currentLine]));
	}
}
