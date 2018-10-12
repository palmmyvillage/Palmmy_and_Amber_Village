using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSPchange : MonoBehaviour {

	//Set Bool for check current sprite
	public Boolean Sprite01Checked = true;
	
	//Set Sprite01 and 02
	public Material Sprite01;
	public Material Sprite02;
	
	//Set timer for sprite change
	private float SpriteTimer = 0.0f;
	
	// Use this for initialization
	void Start () {
		
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
				gameObject.GetComponent<MeshRenderer>().material = Sprite02;
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
				gameObject.GetComponent<MeshRenderer>().material = Sprite01;
				SpriteTimer = 0.0f;
				Sprite01Checked = true;
			} 
			
		}
	}
}
