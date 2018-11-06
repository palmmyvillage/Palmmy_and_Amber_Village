using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackGround : MonoBehaviour {

	// set var to store X coordinate
	public float Xpos;
	public float Ypos;
	private RectTransform MyRectTran;

	// Use this for initialization
	void Start ()
	{
		Ypos = gameObject.GetComponent<RectTransform>().anchoredPosition.y;
		MyRectTran = gameObject.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		MyRectTran.localPosition -= new Vector3(0.5f,0,0);
		Xpos = gameObject.GetComponent<RectTransform>().anchoredPosition.x;

		if (Xpos <= -798f)
		{
			Xpos = 798.1f;
			MyRectTran.localPosition = new Vector3(Xpos,Ypos,0);
		}

	}
}
