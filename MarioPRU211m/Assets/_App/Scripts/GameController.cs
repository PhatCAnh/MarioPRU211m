using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] private GameObject _mapElement;
    
    [SerializeField] private GameObject _mapParent;
    public bool IsStop => isLoseGame;

    public bool isLoseGame;

    private void Awake()
    {
        instance = this;
    }

    public float speedMoveMap;

    public void DoneMapMove()
    {
        var map = Instantiate(_mapElement, Vector2.right * 30, Quaternion.identity);
        map.transform.SetParent(_mapParent.transform);
    }

    public void LoseGame()
    {
        Debug.Log("loseGame");
        isLoseGame = true;
    }
}
