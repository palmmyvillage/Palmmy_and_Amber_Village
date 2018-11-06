using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateNaming : MonoBehaviour {

	// set var to see what line need to activate naming
	public int NamingLine;
	
	// set NamingBox
	public GameObject NamingBox;
	public InputField NamingField;
	
	// set boolean to check if activate or not
	public Boolean NamingFieldActivated;
	
	// Use this for initialization
	void Start ()
	{

		NamingField = NamingBox.GetComponent<InputField>();
		
		// set NamingFieldActivated to false
		NamingFieldActivated = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (gameObject.GetComponent<DialogueBoxForMenu>().currentLine == NamingLine)
		{
			if (NamingFieldActivated == false)
			{
				NamingBox.SetActive(true);
				NamingField.ActivateInputField();
				print("LOL");
			}
		}
	}
}
