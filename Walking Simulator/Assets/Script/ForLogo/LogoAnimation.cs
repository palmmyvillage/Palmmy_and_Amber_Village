using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoAnimation : MonoBehaviour {

	// set plainWhite gameobject
	public GameObject PlainWhite;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// set plain white animation
	void WhiteBlink()
	{
		PlainWhite.SetActive(true);
	}
}
