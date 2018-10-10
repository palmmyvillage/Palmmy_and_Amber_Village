using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : MonoBehaviour{

	public float ResponseSpeed = 1.0f;
	public float WalkingSpeed = 1.0f;
	private Vector3 contactPoint;
	
	// Use this for initialization
	void Start () 
	{
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float translation = Input.GetAxis("Vertical")*ResponseSpeed;
		float straffe = Input.GetAxis("Horizontal")*ResponseSpeed;
		translation *= WalkingSpeed*Time.deltaTime;
		straffe *= WalkingSpeed*Time.deltaTime;
		
		transform.Translate(straffe,0,translation);
		
		if (Input.GetKeyDown("escape"))
		{
			Cursor.lockState = CursorLockMode.None;
		}
	}
	
	void OnControllerColliderHit (ControllerColliderHit hit) {
		contactPoint = hit.point;
	}
	
	// Store point that we're in contact with for use in FixedUpdate if needed
}
