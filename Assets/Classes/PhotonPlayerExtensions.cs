// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using Hashtable = ExitGames.Client.Photon.Hashtable;

static class PhotonPlayerExtensions
{
	public static bool movementEnabled(this PhotonPlayer player)
	{
		bool retVal = false;
		object ready;
		if (player.customProperties.TryGetValue(PlayerConstants.movementEnabledKey, out ready))
		{
			retVal = (bool)ready;
		}
		return retVal;
	}

	public static void setMovementEnabled(this PhotonPlayer player, bool enabled)
	{
		if (!PhotonNetwork.connectedAndReady)
		{
			Debug.LogWarning("setReadyToRace was called in state: " + PhotonNetwork.connectionStateDetailed + ". Not connectedAndReady.");
		}

		Hashtable properties = new Hashtable();
		properties.Add(PlayerConstants.movementEnabledKey, enabled);
		player.SetCustomProperties(properties);
	}

	public static void enableMovement(this PhotonPlayer player)
	{
		player.setMovementEnabled(true);
	}

	public static void disableMovement(this PhotonPlayer player)
	{
		player.setMovementEnabled(false);
	}

	public static bool needsToAttachCamera(this PhotonPlayer player)
	{
		bool retVal = false;
		object ready;
		if (player.customProperties.TryGetValue(PlayerConstants.needsToAttachCameraKey, out ready))
		{
			retVal = (bool)ready;
		}
		return retVal;
	}

	public static void setNeedsToAttachCamera(this PhotonPlayer player, bool attachCamera)
	{
		if (!PhotonNetwork.connectedAndReady)
		{
			Debug.LogWarning("setReadyToRace was called in state: " + PhotonNetwork.connectionStateDetailed + ". Not connectedAndReady.");
		}

		bool needsToAttachCamera = PhotonNetwork.player.needsToAttachCamera();
		Hashtable properties = new Hashtable();
		properties.Add(PlayerConstants.needsToAttachCameraKey, attachCamera);
		player.SetCustomProperties(properties);
	}

	public static void attachCamera(this PhotonPlayer player)
	{
		player.setNeedsToAttachCamera(true);
	}

	public static bool readyToRace(this PhotonPlayer player)
	{
		bool retVal = false;
		object ready;
		if (player.customProperties.TryGetValue(PlayerConstants.readyToRaceKey, out ready))
		{
			retVal = (bool)ready;
		}
		return retVal;
	}

	public static void setReadyToRace(this PhotonPlayer player, bool ready)
	{
		if (!PhotonNetwork.connectedAndReady)
		{
			Debug.LogWarning("setReadyToRace was called in state: " + PhotonNetwork.connectionStateDetailed + ". Not connectedAndReady.");
		}

		bool readyToRace = PhotonNetwork.player.readyToRace();
		if (ready != readyToRace)
		{
			Hashtable properties = new Hashtable();
			properties.Add(PlayerConstants.readyToRaceKey, ready);
			player.SetCustomProperties(properties);
		}
	}

	public static bool crossedFinishLine(this PhotonPlayer player)
	{
		bool retVal = false;
		object ready;
		if (player.customProperties.TryGetValue(PlayerConstants.crossedFinishLineKey, out ready))
		{
			retVal = (bool)ready;
		}
		return retVal;
	}

	public static void setCrossedFinishLine(this PhotonPlayer player, bool crossed)
	{
		if (!PhotonNetwork.connectedAndReady)
		{
			Debug.LogWarning("setReadyToRace was called in state: " + PhotonNetwork.connectionStateDetailed + ". Not connectedAndReady.");
		}

		bool crossedFinishLine = PhotonNetwork.player.crossedFinishLine();
		if (crossedFinishLine != crossed)
		{
			Hashtable properties = new Hashtable();
			properties.Add(PlayerConstants.crossedFinishLineKey, crossed);
			player.SetCustomProperties(properties);
		}
	}

	public static int playerNumber(this PhotonPlayer player)
	{
		int retVal = 0;
		object number;
		if (player.customProperties.TryGetValue(PlayerConstants.playerNumberKey, out number))
		{
			retVal = (int)number;
		}
		return retVal;
	}

	public static void setPlayerNumber(this PhotonPlayer player, int number)
	{
		if (!PhotonNetwork.connectedAndReady)
		{
			Debug.LogWarning("setReadyToRace was called in state: " + PhotonNetwork.connectionStateDetailed + ". Not connectedAndReady.");
		}

		int playerNumber = PhotonNetwork.player.playerNumber();
		if (number != playerNumber)
		{
			Hashtable properties = new Hashtable();
			properties.Add(PlayerConstants.playerNumberKey, number);
			player.SetCustomProperties(properties);
		}
	}

	public static int totalPoints(this PhotonPlayer player)
	{
		int retVal = 0;
		object number;
		if (player.customProperties.TryGetValue(PlayerConstants.totalPointsKey, out number))
		{
			retVal = (int)number;
		}
		return retVal;
	}

	public static void setTotalPoints(this PhotonPlayer player, int number)
	{
		if (!PhotonNetwork.connectedAndReady)
		{
			Debug.LogWarning("setReadyToRace was called in state: " + PhotonNetwork.connectionStateDetailed + ". Not connectedAndReady.");
		}

		int points = PhotonNetwork.player.totalPoints();
		if (number != points)
		{
			Hashtable properties = new Hashtable();
			properties.Add(PlayerConstants.totalPointsKey, number);
			player.SetCustomProperties(properties);
		}
	}

	public static void incrementTotalPoints(this PhotonPlayer player, int number)
	{
		int newTotal = player.totalPoints() + number;
     	player.setTotalPoints(newTotal);
   }

   	public static void updatePosition(this PhotonPlayer player, Vector3 position)
   	{
   		if (!PhotonNetwork.connectedAndReady)
   		{
   			Debug.LogWarning("setReadyToRace was called in state: " + PhotonNetwork.connectionStateDetailed + ". Not connectedAndReady.");
   		}

   		Hashtable properties = new Hashtable();
   		properties.Add(PlayerConstants.updatePositionKey, position);
   		player.SetCustomProperties(properties);
   	}

	public static void updatePositionBackToStart(this PhotonPlayer player)
	{
        Vector3 startPosition = PlayerStartPositionProvider.startPositionForPlayer(player);
		player.updatePosition(startPosition);
    }
}
