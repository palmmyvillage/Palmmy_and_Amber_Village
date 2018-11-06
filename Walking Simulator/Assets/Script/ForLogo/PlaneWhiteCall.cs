using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneWhiteCall : MonoBehaviour {

	// Set Menu and other Logo
	public GameObject Princess;
	public GameObject Mountain;
	public GameObject StartMenu;
	public GameObject Decoration;
	public GameObject TutorialMenu;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// set plain white to call others
	void CallMenu()
	{
		Princess.SetActive(true);
		Mountain.SetActive(true);
		StartMenu.SetActive(true);
		Decoration.SetActive(true);
		Destroy(gameObject);
		
	}
	
	// set function to destroy itself after use
	void SelfDestroy()
	{
		Destroy(gameObject);
	}
}
