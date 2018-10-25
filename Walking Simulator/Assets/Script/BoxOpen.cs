using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOpen : MonoBehaviour
{
    //set string for PlayerRigidBody Name
    public String PlayerRigidBody;
	
    //set var of soundeffect
    private AudioSource GetitemSound;
	
    // set alternate sprite
    public Sprite BoxOpenedSP;
	
    // set boolean for checking collision
    private Boolean Touching;
	
    // set timelimit for open and get item
    private Boolean soundOpenPlay;
	
    //set controller so that when talk player staystill
    public CharacterController Player_Controller;
    //set player to find then to disable mouselook script
    public GameObject Player;
	
    //set var for item give
    public GameObject Equipment;
	
    // Use this for initialization
    void Start ()
    {
        Touching = false;
        GetitemSound = GetComponent<AudioSource>();
        soundOpenPlay = false;
    }
	
    // Update is called once per frame
    void Update ()
    {

        if (Touching == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (soundOpenPlay == false)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = BoxOpenedSP;
				
                    Player.GetComponent<AudioSource>().Pause();
                    //	gameObject.GetComponent<CheckColforDia>().enabled = false;
                    gameObject.GetComponent<DialogueBoxManager>().SoundIsPlaying = true;
                    GetitemSound.Play(0);
                    soundOpenPlay = true;
                }
            }
        }
		

        if (soundOpenPlay == true)
        {
            if (GetitemSound.isPlaying == false)
            {
                Player.GetComponent<AudioSource>().UnPause();
                gameObject.GetComponent<DialogueBoxManager>().SoundIsPlaying = false;
				
                // check if give sword or shield
                Equipment.SetActive(true);
            }
        }

    }
	
    // Collision is called when happen
    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.name.Equals(PlayerRigidBody))
        {
            Touching = true;
        }
    }
	
    // Collision is called when exit from colliding
    void OnCollisionExit (Collision col)
    {
        if (col.gameObject.name.Equals(PlayerRigidBody))
        {
            Touching = false;
        }
    }
}