using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using _App.Scripts;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public enum GameState
{
    Ready,
    Playing,
    Pause,
    Lose,
}

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] private GameObject[] _mapElement;
    
    [SerializeField] private GameObject _mapParent;

    public float timeRunGame;

    public float metRun;
    
    public float speedMoveMap = 3f;
    public bool isStop => gameState != GameState.Playing;
    
    private UIController uiController => UIController.instance;

    

    public Character characterPrefab;

    public GameState gameState;

    public Character character;

    public int coinCollected;

    private void Awake()
    {
        instance = this;
    }


    public void DoneMapMove()
    {
        int numberRandom = Random.Range(0, _mapElement.Length);
        var map = Instantiate(_mapElement[numberRandom], Vector2.right * 30, Quaternion.identity);
        map.transform.SetParent(_mapParent.transform);
    }

    public void StartGame()
    {
        gameState = GameState.Playing;
        character = Instantiate(characterPrefab, new Vector3(-5, 4.5f), quaternion.identity);
    }

    public async void LoseGame()
    {
        gameState = GameState.Lose;
        if(PlayerPrefs.GetInt("BestMetPoint") < metRun)
        {
            PlayerPrefs.SetInt("BestMetPoint", Mathf.RoundToInt(metRun));
        }
        AudioController.instance.SoundGameOver();
        await Task.Delay(2700);
        SceneManager.LoadScene("SampleScene");
    }
    
    public string UpdateTimeRunGameUI()
    {
        var value = timeRunGame;
        var minutes = Mathf.FloorToInt(value / 60f);
        var seconds = Mathf.FloorToInt(value - minutes * 60);
        var timeStr = $"{minutes:00} : {seconds:00}";
        if(timeRunGame > 5f)
        {
            UpdateSpeedMap();
        }
        return timeStr;
    }

    public void UpdateSpeedMap()
    {
        var speed = timeRunGame / 7.5f;
        speedMoveMap = Mathf.Clamp(speed, 3f, 10f);
        character.anim.SetFloat("speedRun", Mathf.Clamp(speedMoveMap / 5, 1f, 3f));
    }

    public void CollectedCoin(Coin coin)
    {
        coinCollected++;
        uiController.UpdateUICollectedCoin();
        AudioController.instance.audioCollectedCoin.Play();
        Destroy(coin.gameObject);
    }
}
