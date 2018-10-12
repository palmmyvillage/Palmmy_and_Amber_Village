using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOpen : MonoBehaviour
{
	// set alternate sprite
	public Material OpenedBox;
	
	// set boolean for checking collision
	private Boolean Touching;
	
	// Use this for initialization
	void Start ()
	{
		Touching = false;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Touching == true)
		{
			if (Input.GetMouseButtonDown(0))
			{
				gameObject.GetComponent<MeshRenderer>().material = OpenedBox;
			}
		}
		else
		{
		}

	}
	
	// Collision is called when happen
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name.Equals("ForInteraction"))
		{
			Touching = true;
		}
	}
	
	// Collision is called when exit from colliding
	void OnCollisionExit (Collision col)
	{
		if (col.gameObject.name.Equals("ForInteraction"))
		{
			Touching = false;
		}
 	}
 }
