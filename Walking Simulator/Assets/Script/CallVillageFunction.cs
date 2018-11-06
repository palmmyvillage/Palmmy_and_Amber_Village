using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CallVillageFunction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	// Go to Village
	void MoveToVillage()
	{
		SceneManager.LoadScene("Village_Scene");
	}
}
