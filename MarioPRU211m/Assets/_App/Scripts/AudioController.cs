using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
	public static AudioController instance;

	private void Awake()
	{
		instance = this;
	}

	public AudioSource audioBackground, audioPlayerDie, audioCollectedCoin;

	public void SoundGameOver()
	{
		audioBackground.Pause();
		audioPlayerDie.Play();
	}
}
