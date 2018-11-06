using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmberPalmmyStart : MonoBehaviour
{
	// set aimator
	public Animator Animator;
	
	// set Logo
	public GameObject Logo;
	
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// use for call animation end
	void StartDisappearing()
	{
		Animator.SetBool("GoDisappear", true);
	}
	
	// use for call Logo to appear
	void CallLogo()
	{
		print("callLOGO");
		Logo.SetActive(true);
		Destroy(gameObject);
	}
}
