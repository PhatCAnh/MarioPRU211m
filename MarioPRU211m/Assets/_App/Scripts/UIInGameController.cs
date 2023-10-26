using System;
using TMPro;
using UnityEngine;
namespace _App.Scripts
{
	public class UIController : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _txtTimeRunGame;
		
		private GameController gameController => GameController.instance;

		private void Update()
		{
			gameController.timeRunGame += Time.deltaTime;
			UpdateTimeRunGameUI();
		}

		private void UpdateTimeRunGameUI()
		{
			var value = gameController.timeRunGame;
			var minutes = Mathf.FloorToInt(value / 60f);
			var seconds = Mathf.FloorToInt(value - minutes * 60);
			var timeStr = $"{minutes:00} : {seconds:00}";
			_txtTimeRunGame.text = timeStr;
		}
	}
}