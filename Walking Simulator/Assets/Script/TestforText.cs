using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class TestforText : MonoBehaviour {
	
	// choose the UItext we already put into scene to set where they gonna appear
	public Text TextPosition;
	
	// choose the UiTextBox we already put into scene (Dont need to if will not use any box)
	public GameObject TextBox;
	
	// Choose the text file that gonna be used
	public TextAsset TextFile;
	
	// Set string to indicate which line from "TextFile" gonne be shown up at that moment
	private string[] TextLine;
	
	// Set int var to store the number of Current Line and the End Line
	private int CurrentLine;
	private int EndLine;
	

	// Use this for initialization
	void Start () {
		
		// set if the TextFile has been assigned then TextLine will be split with \n
		if (TextFile != null)
		{
			TextLine = TextFile.text.Split('\n');
		}
		
		// set the end line to be assigned automatically to the number of line in the selected TextFile
		EndLine = TextLine.Length - 1;
		
		// in my script I have "if" function becuz I set EndLine as public in case I want to manually set where it end 

	}
	
	// Update is called once per frame
	void Update () {
		
		// for all this to happen I write another script just to work as a collision and mouse click detector
		// so that this script only work when mouse click while Player Touch object/NPC
		
		// set that every frame UItext will show the current TextLine
		TextPosition.text = TextLine[CurrentLine];
		
		// check if there is a left click, the line will move by 1
		if (Input.GetMouseButtonDown(0))
		{
			CurrentLine += 1;
		}
		
		// check if TextEnd then...do whatever
		if (CurrentLine >= EndLine)
		{
			TextPosition.enabled = false;
			TextBox.SetActive(false);
		}
	}
}
