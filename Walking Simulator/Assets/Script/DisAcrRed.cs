using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisAcrRed : MonoBehaviour {
	
	//set controller so that when talk player staystill
	public CharacterController Player_Controller;
	//set player to find then to disable mouselook script
	public GameObject Player;

	public GameObject RuinedCaveHole;

	// Use this for initialization
	void Start () {
		//set player to be PlayerContoller
		Player_Controller = FindObjectOfType<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// disactitself and react playercon
	void DisActSelf()
	{
		Player_Controller.enabled = true;
		Player.GetComponent<MouseLook>().enabled = true;
		gameObject.SetActive(false);
	}
	
	// set static bool to change world
	void RuinedWorld()
	{
		NameStorage.WorldRuined = true;
		RuinedCaveHole.GetComponent<BackToCastleColi>().enabled = false;
		RuinedCaveHole.GetComponent<GotoCaveColi>().enabled = true;
	}
}
