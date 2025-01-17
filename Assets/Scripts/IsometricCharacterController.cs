﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCharacterController : MonoBehaviour {

	[SerializeField]
	float moveSpeed = 4f;

	Vector3 forward, right;

	// Use this for initialization
	void Start () {

		forward = Camera.main.transform.forward;
		forward.y = 0;
		forward = Vector3.Normalize(forward);

		right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.anyKey)
		{
			Move();
		}

	}

	void Move() {
		Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
		Vector3 horizMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
		Vector3 vertMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

		Vector3 heading = Vector3.Normalize(horizMovement + vertMovement);

		transform.forward = heading;
		transform.position += horizMovement;
		transform.position += vertMovement;

	}

}
