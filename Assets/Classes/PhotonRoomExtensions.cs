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
using System.Collections.Generic;

static class PhotonRoomExtensions
{
	public static bool allPlayersAreReadyToRace(this Room room)
	{
		bool allPlayersAreReady = true;
		foreach(PhotonPlayer player in PhotonNetwork.playerList)
		{
			if (player.readyToRace() == false)
			{
				allPlayersAreReady = false;
				break;
			}
      }
      return allPlayersAreReady;
   }
}

