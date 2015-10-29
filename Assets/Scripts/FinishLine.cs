﻿using UnityEngine;
using System.Collections;

public class FinishLine : Photon.MonoBehaviour
{
	public EdgeCollider2D edgeCollider;
	public GameObject finishLineText;
	public CounterUI finishLineCounter;

	void Start()
	{
		finishLineText.SetActive(false);
	}
	
	private void OnTriggerExit2D(Collider2D other)
	{
		float edgeTransformY = edgeCollider.transform.position.y + edgeCollider.offset.y;
		if (other.transform.position.y > edgeTransformY)
		{
			GameObject player = other.transform.root.gameObject;
			NetworkPlayerNumberSetup numberSetup = player.GetComponent<NetworkPlayerNumberSetup>();
			if (numberSetup != null)
			{
				activateAndUpdateFinishLineText(numberSetup.playerNumber);
				photonView.RPC("activateAndUpdateFinishLineText", PhotonTargets.OthersBuffered, numberSetup.playerNumber);
			}
		}
	}

	[PunRPC] void activateAndUpdateFinishLineText(int playerNumber)
	{
		finishLineText.SetActive(true);
		finishLineCounter.updateSpritesWithNumber(playerNumber);
	}
}
