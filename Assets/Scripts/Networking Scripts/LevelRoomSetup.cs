﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class LevelRoomSetup : Photon.PunBehaviour 
{
	public CountdownManager countdownManager;
	public LevelComponentsManager levelSetup;
	public NetworkPlayerManager playersManager;
	private Room currentRoom { get { return PhotonNetwork.room; } }
	private bool roomIsFull { get { return currentRoom.maxPlayers == currentRoom.playerCount; }}

	void OnLevelWasLoaded(int level)
	{
		if (level == 1 && PhotonNetwork.connectedAndReady)
		{
			List<Vector3> startPositions = PlayerStartPositionProvider.startPositionsForRoomSize(currentRoom.maxPlayers);
			
			// Get the start position that corresponds to THIS player
			Vector3 startPos = startPositions[PhotonNetwork.player.ID-1];
			playersManager.createPlayerAtPosition(startPos);
		}
	}

	void Start()
	{
		setupCountdownManager();
//		photonView.RPC("beginCountdown", PhotonTargets.AllViaServer);
	}

	[PunRPC] void beginCountdown()
	{
		if (countdownManager != null)
		{
			countdownManager.showCountdownUI();
			countdownManager.beginCountdown();
		}
	}

	private void setupCountdownManager()
	{
		if (countdownManager != null)
		{
			countdownManager.hideCountdownUI();

			countdownManager.completion += countdownManager.hideCountdownUI;
			countdownManager.completion += levelSetup.activateMovingLevelComponents;
			countdownManager.completion += playersManager.enablePlayerMovement;
		}
	}
}