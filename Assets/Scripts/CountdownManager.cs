﻿using UnityEngine;
using System.Collections;

public class CountdownManager : MonoBehaviour
{
	public delegate void CountdownCompletion();
	public NetworkRoomCountdownTimer timer;
	public CounterUI counterUI;
	public int countdownDuration = 5;

	private bool timerStarted = false;
	public CountdownCompletion completion;

	void Start()
	{
		timer.SecondsPerTurn = 5;
	}

	void Update()
	{
		if (timerStarted)
		{
			int secondsLeft = Mathf.CeilToInt(timer.remainingTimeInCurrentTurn());
			counterUI.updateSpritesWithNumber(secondsLeft);

			if (timer.currentTurn() != 0 && completion != null)
			{
				timerStarted = false;
				completion();
			}
		}
	}

	public void beginCountdownWithSeconds(int seconds, CountdownCompletion completion)
	{
		if (timerStarted == false)
		{
			this.completion = completion;
			timer.SecondsPerTurn = seconds;

			timer.startRound();
			timerStarted = true;
		}
	}

	public void beginCountdown()
	{
		if (!timerStarted)
		{
			timer.SecondsPerTurn = countdownDuration;
			timer.startRound();
			timerStarted = true;
		}
	}

	public void showCountdownUI()
	{
		counterUI.setDigitAlpha(1);
	}

	public void hideCountdownUI()
	{
		counterUI.setDigitAlpha(0);
	}
}
