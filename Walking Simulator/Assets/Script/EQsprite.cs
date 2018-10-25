using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EQsprite : MonoBehaviour {

	//Set Bool for check current sprite
	public Boolean Sprite01Checked = true;
	
	//Set Sprite01 and 02
	public float Up;
	public float Down;
	
	//Set timer for sprite change
	private float SpriteTimer = 0.0f;
	private float posX;
	private float posZ;
	
	// Use this for initialization
	void Start ()
	{
		posX = gameObject.GetComponent<Transform>().position.x;
		posZ = gameObject.GetComponent<Transform>().position.z;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// increase timer every frmae
		SpriteTimer += Time.deltaTime;
		
		//check if current sprite is sprite 01
		if (Sprite01Checked == true)
		{
			//set timer limit to change sprite
			if (SpriteTimer >= 0.5f)
			{
				gameObject.transform.position = new Vector3(posX, Up, posZ);
				SpriteTimer = 0.0f;
				Sprite01Checked = false;
			} 
		}
		//check if current sprite is sprite 02
		else
		{
			//set timer limit to change sprite
			if (SpriteTimer >= 0.5f)
			{
				gameObject.transform.position = new Vector3(posX, Down, posZ);
				SpriteTimer = 0.0f;
				Sprite01Checked = true;
			} 
			
		}
	}
}
