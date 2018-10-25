using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLook : MonoBehaviour
{
	private GameObject player;
	private Vector3 PlayerLocation;

	// Use this for initialization
	void Start () {
		
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		PlayerLocation = new Vector3(player.transform.position.x, 0.5f , player.transform.position.z);
		transform.LookAt(PlayerLocation);
	}
}