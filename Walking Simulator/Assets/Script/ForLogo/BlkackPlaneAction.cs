using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlkackPlaneAction : MonoBehaviour {

	// set var for storing GameObject. Mainmenu
	public GameObject MainMenu;
	public GameObject NamingMenu;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// set function to disable main menu and enable naming menu
	void DisableMainMenu()
	{
		MainMenu.SetActive(false);
		NamingMenu.SetActive(true);
		
	}
}
