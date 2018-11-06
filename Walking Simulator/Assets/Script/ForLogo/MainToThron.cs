using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainToThron : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// set function to call 2nd scene
	void MoveToThroneRoom()
	{
		SceneManager.LoadScene("Throne_Scene");
	}
}
