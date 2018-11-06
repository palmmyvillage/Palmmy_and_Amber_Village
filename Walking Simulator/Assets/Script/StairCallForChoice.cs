using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StairCallForChoice : MonoBehaviour {
	
	public Text Choice1Pos;
	public string Choice1Content;

	public Text Choice2Pos;
	public string Choice2Content;

	public int LineofQ;
	
	// set var to check
	

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Do this when awake
	void OnEnable()
	{
		gameObject.GetComponent<StairDialogueManager>().Quiz = true;
		Choice1Pos.text = Choice1Content;
		Choice2Pos.text = Choice2Content;
	}
}
