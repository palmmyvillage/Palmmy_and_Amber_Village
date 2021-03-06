﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private Boolean Pause;
	
    //set controller so that when talk player staystill
    public CharacterController Player_Controller;
    //set player to find then to disable mouselook script
    public GameObject BGM;
	
    //set var for item give
    public GameObject Equipment;
    
    //stop sword and shield
    private GameObject Sword;
    private GameObject Shield;
    private GameObject Money;
	
    // Use this for initialization
    void Start ()
    {
        Touching = false;
        GetitemSound = GetComponent<AudioSource>();
        soundOpenPlay = false;
        Pause = true;
        
        Sword =  GameObject.Find("Sword");
        Shield = GameObject.Find("Shield");
        Money = GameObject.Find("Money");
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
				
                    BGM.GetComponent<AudioSource>().Pause();
                    //	gameObject.GetComponent<CheckColforDia>().enabled = false;
                    gameObject.GetComponent<DialogueBoxManager>().SoundIsPlaying = true;
                    GetitemSound.Play(0);
                    soundOpenPlay = true;
                    
                    // set sword and shield to stop animating
                    Sword.GetComponent<EQsprite>().enabled = false;
                    Shield.GetComponent<EQsprite>().enabled = false;
                }
            }
        }
		

        if (soundOpenPlay == true && Pause == true)
        {
            if (GetitemSound.isPlaying == false)
            {
                BGM.GetComponent<AudioSource>().UnPause();
                gameObject.GetComponent<DialogueBoxManager>().SoundIsPlaying = false;
                
                Sword.GetComponent<EQsprite>().enabled = true;
                Shield.GetComponent<EQsprite>().enabled = true;
				
                // check if give sword or shield
                if (Equipment == Sword || Equipment == Shield)
                {
                    Equipment.GetComponent<Image>().color = new Color(255,255,255,1f);
                    
                    if (Equipment == Sword)
                    {
                        NameStorage.GetSword = true;
                        print(NameStorage.GetSword);
                    }
                    if (Equipment == Shield)
                    {
                        NameStorage.GetShield = true;
                        print(NameStorage.GetShield);
                    }
                }
           
                if (Equipment == Money)
                {
                    NameStorage.GetMoney = true;
                    print(NameStorage.GetMoney);
                }
                
 
                
                Pause = false;
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