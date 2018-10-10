using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MouseLookCam : MonoBehaviour {
	
	Vector2 mouselook;
	Vector2 smoothV;
	public float sensitivity = 2.0f;
	public float smoothing = 2.0f;

	GameObject character;

	// Use this for initialization
	void Start()
	{
		character = this.transform.parent.gameObject;
	}

	// Update is called once per frame
	void Update()
	{
		var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

		md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
		smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1.0f / smoothing);
		//smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1.0f / smoothing);
		mouselook += smoothV;
		
		transform.localRotation = Quaternion.AngleAxis(-mouselook.y,Vector3.right);
		character.transform.localRotation = Quaternion.AngleAxis(mouselook.x, character.transform.up);
	}
}
