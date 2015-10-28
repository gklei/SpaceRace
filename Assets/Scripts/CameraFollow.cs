﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public Transform objectToFollow;
	public float yTrackingSpeed;
	public float xTrackingSpeed;
	public bool lockXPosition = false;

	Transform trans;
	float lookAheadDistance;

	// Use this for initialization
	void Start () 
	{
		trans = transform;

		// 1/6 of the camera height. We use this to center the player 1/3 of the way up the screen
		lookAheadDistance = Camera.main.orthographicSize / 3.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float newXPosition = trans.position.x;
		if(!lockXPosition)
		{
			newXPosition = Mathf.Lerp(trans.position.x, objectToFollow.position.x, xTrackingSpeed);
		}
		float newYPosition = Mathf.Lerp(trans.position.y, objectToFollow.position.y + lookAheadDistance, yTrackingSpeed);

		trans.position = new Vector3(newXPosition, newYPosition, trans.position.z);
	}
}
