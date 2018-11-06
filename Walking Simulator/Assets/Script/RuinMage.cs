using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuinMage : MonoBehaviour {

	public Sprite RuinedSprite01;
	public Sprite RuinedSprite02;

	public TextAsset RuinedText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (NameStorage.WorldRuined == true)
		{
			gameObject.GetComponent<SoldierSPchange>().Sprite01 = RuinedSprite01;
			gameObject.GetComponent<SoldierSPchange>().Sprite02 = RuinedSprite02;
		}
		
	}
}
