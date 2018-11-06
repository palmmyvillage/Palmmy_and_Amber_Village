using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingChoice : MonoBehaviour
{

	public GameObject ChoiceBox;
	public GameObject NamingMenuManage;

	// set pos
	public float Xpos;
	public float Ypos;
	private RectTransform ChoiceRectTrans;

	// set status as Yes or No
	private Boolean Status;

	// set Ypos for both Choices
	public float YesPos;
	public float NoPos;

	// set gameobject to store namingfield
	public GameObject NamingBox;
	private InputField NamingField;

	// Use this for initialization
	void Start()
	{
		Status = false;

		YesPos = 22.5f;
		NoPos = -23.5f;

		Xpos = gameObject.GetComponent<RectTransform>().anchoredPosition.x;
		Ypos = gameObject.GetComponent<RectTransform>().anchoredPosition.y;

		ChoiceRectTrans = gameObject.GetComponent<RectTransform>();

		NamingField = NamingBox.GetComponent<InputField>();
	}

	// Update is called once per frame
	void Update()
	{

		if (Status == true)
		{
			ChoiceRectTrans.localPosition = new Vector3(Xpos, YesPos, 0);

			// when press up or down
			if (Input.GetButtonDown("Vertical") && !Input.GetButtonDown("Submit") && !Input.GetMouseButtonDown(0))
			{
				Status = false;
			}

			// when press enter
			if (!Input.GetButtonDown("Vertical"))
			{
				if (Input.GetButtonDown("Submit") || Input.GetMouseButtonDown(0))
				{
					NameStorage.CharacterName = NamingBox.GetComponent<InputField>().text;
					
					NamingMenuManage.GetComponent<DialogueBoxForMenu>().currentLine += 1;
					NamingMenuManage.GetComponent<DialogueBoxForMenu>().ForceCoroutine();
					NamingMenuManage.GetComponent<DialogueBoxForMenu>().WaitForAnswer = false;

					print(NameStorage.CharacterName);
					NamingBox.SetActive(false);
					ChoiceBox.SetActive(false);
					
					
				}
			}
		}
		else
		{
			ChoiceRectTrans.localPosition = new Vector3(Xpos, NoPos, 0);
			// when press up or down
			if (Input.GetButtonDown("Vertical") && !Input.GetButtonDown("Submit") && !Input.GetMouseButtonDown(0))
			{
				Status = true;
			}

			// when press enter
			if (!Input.GetButtonDown("Vertical"))
			{
				if (Input.GetButtonDown("Submit") || Input.GetMouseButtonDown(0))
				{
					NamingMenuManage.GetComponent<DialogueBoxForMenu>().currentLine -= 1;
					NamingMenuManage.GetComponent<DialogueBoxForMenu>().ForceCoroutine();
					
					NamingMenuManage.GetComponent<ActivateChoices>().Done = false;
					NamingMenuManage.GetComponent<ActivateNaming>().NamingFieldActivated = false;

					NamingField.enabled = true;
					NamingField.ActivateInputField();
					ChoiceBox.SetActive(false);
					
					print("Heii");
				}
			}
		}

	}
}

