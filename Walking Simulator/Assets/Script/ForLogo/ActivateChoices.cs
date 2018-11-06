using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateChoices : MonoBehaviour {
	
	//set var to save CHoice Box1
	public Text ChoiceText01;
	public string ChoiceFile01;
	
	//set var to save CHoice Box2
	public Text ChoiceText02;
	public string ChoiceFile02;
	
	// set gameobject to store namingfield
	public GameObject NamingBox;
	private InputField NamingField;
	
	// set variable to see if done with name or not
	public Boolean Done;
	
	// set boolean check for allow to enter
	public Boolean Allow;
	
	

	// Use this for initialization
	void Start ()
	{
		ChoiceText01.text = ChoiceFile01;
		ChoiceText02.text = ChoiceFile02;
		
		NamingField = NamingBox.GetComponent<InputField>();

		Done = false;

		Allow = false;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (NamingField.text != "" && Done == false && Allow == true) 
		{
			if (Input.GetButtonDown("Submit"))
			{
				gameObject.GetComponent<DialogueBoxForMenu>().SetMovingChoiceActive = true;
				gameObject.GetComponent<ActivateNaming>().NamingFieldActivated = true;
				NamingField.enabled = false;
				Done = true;
				Allow = false;
				print("Palmmy");
				
				gameObject.GetComponent<DialogueBoxForMenu>().currentLine += 1;
				gameObject.GetComponent<DialogueBoxForMenu>().ForceCoroutine();
			}
		}
	}
}
