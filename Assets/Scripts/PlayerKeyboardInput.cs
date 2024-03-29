﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerKeyboardInput : Photon.MonoBehaviour
{
	public bool player1 = true;
	public MovePlayer movePlayer;

	void Update()
	{
		if (photonView == null || photonView.isMine)
		{
			KeyCode rightMovementCode = player1 ? KeyCode.RightArrow : KeyCode.Period;
			KeyCode leftMovementCode = player1 ? KeyCode.LeftArrow : KeyCode.Comma;
			
			if (Input.GetKeyDown(leftMovementCode))
			{
				movePlayer.jumpWithDirection(JumpDirection.Left);
			}
			if(Input.GetKeyDown(rightMovementCode))
			{
				movePlayer.jumpWithDirection(JumpDirection.Right);
			}
		}
	}
}
