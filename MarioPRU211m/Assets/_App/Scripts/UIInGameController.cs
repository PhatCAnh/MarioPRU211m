using System;
using System.Globalization;
using System.Runtime.InteropServices;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
namespace _App.Scripts
{
	public class UIController : MonoBehaviour
	{
		public static UIController instance;
		
		[SerializeField] private TextMeshProUGUI _txtMetRun, _txtBestMetRun, _txtStart, _txtCoinCollected;

		[SerializeField] private Button _btnStart, _btnPause, _btnClosePopupPause, _btnRestartPopupPause;

		[SerializeField] private GameObject _pausePopup;
		
		private GameController gameController => GameController.instance;

		private Sequence _sequenceTxtStartGame;

		private GameState _oldGameState;
		
		private void Awake()
		{
			instance = this;
		}

		private void Start()
		{
			_txtBestMetRun.text = $"Best: <size=80%> {PlayerPrefs.GetInt("BestMetPoint", 0):0000}m</size>";
			_txtStart.transform
				.DOScale(Vector3.one * 1.25f, 1f)
				.SetLoops(-1, LoopType.Yoyo)
				.SetEase(Ease.Linear);
			_btnStart.onClick.AddListener(() =>
			{
				gameController.StartGame();
				_btnStart.gameObject.SetActive(false);
			});
			
			_btnPause.onClick.AddListener(PauseGame);
			
			_btnClosePopupPause.onClick.AddListener(UnpauseGame);
			
			_btnRestartPopupPause.onClick.AddListener(RestartGame);
		}

		public void UpdateUICollectedCoin()
		{
			_txtCoinCollected.text = $"Coin Collected: {gameController.coinCollected}";
		}

		private void RestartGame()
		{
			if(PlayerPrefs.GetInt("BestMetPoint") < gameController.metRun)
			{
				PlayerPrefs.SetInt("BestMetPoint", Mathf.RoundToInt(gameController.metRun));
			}

			SceneManager.LoadScene("SampleScene");
		}

		private void PauseGame()
		{
			_pausePopup.SetActive(true);
			Time.timeScale = 0;
			_oldGameState = gameController.gameState;
			gameController.gameState = GameState.Pause;
		}

		private void UnpauseGame()
		{
			_pausePopup.SetActive(false);
			Time.timeScale = 1;
			gameController.gameState = _oldGameState;
		}

		private void Update()
		{
			if(gameController.isStop) return;
			gameController.timeRunGame += Time.deltaTime;
			gameController.metRun += gameController.speedMoveMap * Time.deltaTime;
			Debug.Log($"Met run: {gameController.metRun}");
			gameController.UpdateTimeRunGameUI();
			_txtMetRun.text = $"{gameController.metRun:0000} <size=80%>m</size>";
		}

		private void OnDestroy()
		{
			_txtStart.transform.DOKill();
		}
		
		
	}
}