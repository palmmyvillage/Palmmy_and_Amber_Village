using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageRelease : MonoBehaviour {
	
	//set controller so that when talk player staystill
	public CharacterController Player_Controller;
	//set player to find then to disable mouselook script
	public GameObject Player;

	// Use this for initialization
	void Start () {
		
		//set player to be PlayerContoller
		Player_Controller = FindObjectOfType<CharacterController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// release character
	void ReleaseCharacter()
	{
		Player_Controller.enabled = true;
		Player.GetComponent<MouseLook>().enabled = true;
		gameObject.GetComponent<MageColi>().enabled = false;
	}
}
