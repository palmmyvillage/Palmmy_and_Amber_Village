﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTarget : MonoBehaviour 
{
	public Transform target;
 
	void Update () {
		if (target != null)
		{
			Vector3 targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
			transform.LookAt(targetPos);
		}

	}
}