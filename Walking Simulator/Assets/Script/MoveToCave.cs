using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToCave : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// Function Move to next scene
	void MovingToCave ()
	{
		SceneManager.LoadScene("Cave_Scene");
	}
}
