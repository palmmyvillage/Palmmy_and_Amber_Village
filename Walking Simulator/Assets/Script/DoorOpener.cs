using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour {
    
    //set string for PlayerRigidBody Name
    public String PlayerRigidBody;
	
    //set var of soundeffect
    private AudioSource OpenThingsSound;
	
    //Set song play or not
    private Boolean Songplay;
    //Set timer for DoorCollision to Destroyed
    private float DestroyTimer = 0.0f;
	
    //set var float to be Degree of Circling
    public float DlDegree;
    public float DrDegree;
	
    //set controller so that when talk player staystill
    public CharacterController Player_Controller;
    //set player to find then to disable mouselook script
    public GameObject Player;
	
    //get object DoorLeft and DoorRight
    GameObject DoorLeft;
    GameObject DoorRight;
	
    //set var boolean for checking collision stay
    private Boolean TouchingDoor;
	
    // Use this for initialization
    void Start ()
    {
        DoorLeft = GameObject.Find("DoorLeft");
        DoorRight = GameObject.Find("DoorRight");
		
        OpenThingsSound = GetComponent<AudioSource>();

        Songplay = false;
		
        TouchingDoor = false;
    }
	
    // Update is called once per frame
    void Update () {
        if (TouchingDoor == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OpenThingsSound.Play(0);
				
                Player_Controller.enabled = false;
                Player.GetComponent<MouseLook>().enabled = false;
				
                DoorLeft.transform.rotation = Quaternion.AngleAxis(DlDegree,Vector3.up);
                DoorRight.transform.rotation = Quaternion.AngleAxis(DrDegree,Vector3.up);

                Songplay = true;
                //print("I dont understand");
            }
        }

        if (Songplay == true)
        {
            if (OpenThingsSound.isPlaying == false)
            {
                Player_Controller.enabled = true;
                Player.GetComponent<MouseLook>().enabled = true;
				
                Destroy(gameObject);
            }
        }
    }
	
    // Collision is called when happen
    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.name.Equals(PlayerRigidBody))
        {
            TouchingDoor = true;
        }
    }
	
    // Collision is called when exit from colliding
    void OnCollisionExit (Collision col)
    {
        if (col.gameObject.name.Equals(PlayerRigidBody))
        {
            TouchingDoor = false;
        }
    }
}
