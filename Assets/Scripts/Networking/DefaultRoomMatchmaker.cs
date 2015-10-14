﻿using UnityEngine;
using System;
using System.Collections;

public class DefaultRoomMatchmaker : Photon.PunBehaviour 
{
	const string GAME_VERSION = "0.0.1";
	private const string roomName = "Default";
	private RoomInfo[] roomsList;

	void Start() 
	{
		PhotonNetwork.ConnectUsingSettings(GAME_VERSION);
	}

	void OnGUI()
	{
		if (!PhotonNetwork.connected)
		{
			GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
		}
		else if (PhotonNetwork.room == null)
		{
			// Create Room
			if (GUI.Button(new Rect(0, 0, 175, 30), "Connect to Default Room"))
			{
				RoomOptions roomOptions = new RoomOptions() {
					maxPlayers = 4,
					isVisible = false
				};

				PhotonNetwork.CreateRoom(roomName, roomOptions, TypedLobby.Default);
			}
			
			// Join Room
			if (roomsList != null)
			{
				for (int i = 0; i < roomsList.Length; i++)
				{
					if (GUI.Button(new Rect(100, 250 + (110 * i), 250, 100), "Join " + roomsList[i].name))
						PhotonNetwork.JoinRoom(roomsList[i].name);
				}
			}
		}
	}
	
	void OnReceivedRoomListUpdate()
	{
		roomsList = PhotonNetwork.GetRoomList();
	}
	void OnJoinedRoom()
	{
		Debug.Log("Connected to Room");
	}

	public override void OnJoinedLobby()
	{
		Debug.Log("joined lobby");
		PhotonNetwork.JoinRoom("default");
	}
}
