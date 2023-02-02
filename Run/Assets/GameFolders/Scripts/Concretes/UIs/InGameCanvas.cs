using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCanvas : MonoBehaviour
{
    [SerializeField] GameOverPanel _gameOverPanel;
    [SerializeField] GameObject _gameCompletedPanel;

    private void Awake()
    {
        _gameOverPanel.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        GameManager.Instance.OnGameOver += HandleOnGameOver;
        GameManager.Instance.OnGameCompleted += HandleOnGameCompleted;
    }


    private void OnDisable()
    {
        GameManager.Instance.OnGameOver -= HandleOnGameOver;
        GameManager.Instance.OnGameCompleted -= HandleOnGameCompleted;
    }

    private void HandleOnGameOver()
    {
        _gameOverPanel.gameObject.SetActive(true);
    }
    private void HandleOnGameCompleted()
    {
        _gameCompletedPanel.gameObject.SetActive(true);
    }
}
