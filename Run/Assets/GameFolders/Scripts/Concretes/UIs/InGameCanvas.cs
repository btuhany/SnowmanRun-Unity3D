using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCanvas : MonoBehaviour
{
    [SerializeField] GameOverPanel _gameOverPanel;

    private void Awake()
    {
        _gameOverPanel.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        GameManager.Instance.OnGameOver += HandleOnGameOver;
    }
    private void OnDisable()
    {
        GameManager.Instance.OnGameOver -= HandleOnGameOver;
    }

    private void HandleOnGameOver()
    {
        _gameOverPanel.gameObject.SetActive(true);
    }
}
