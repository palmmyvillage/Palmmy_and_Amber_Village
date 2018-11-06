using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnable : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<DialogueBoxForMenu>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
