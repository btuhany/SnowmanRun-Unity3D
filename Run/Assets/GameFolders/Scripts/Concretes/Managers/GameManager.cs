using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    int _portalNumber = 3;

    public int PortalNumber { get => _portalNumber; set => _portalNumber = value; }

    public event System.Action OnGameOver;
    public event System.Action OnGameCompleted;
    void Awake()
    {
        SingletonThisObject(this);
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        OnGameOver?.Invoke();
    }
    public void GameCompleted()
    {
        Time.timeScale = 0f;
        OnGameCompleted?.Invoke();
    }
    public void ExitGame()
    {
        Debug.Log("Exit clicked");
        Application.Quit();
    }
    public void LoadScene(string sceneName)
    {
        
        ResetScene();
        StartCoroutine(LeadSceneAsync(sceneName)); 
    }
    public void ReLoadScene()
    {
        ResetScene();
        StartCoroutine(ReLoadLevelSceneAsync());
    }
    public void PortalDestroyed()
    {
        _portalNumber--;
        if (_portalNumber == 0)
            GameCompleted();
    }
    private IEnumerator ReLoadLevelSceneAsync()
    {
        Time.timeScale = 1f;
        yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
    private IEnumerator LeadSceneAsync(string sceneName)
    {
        Time.timeScale = 1f;
        yield return SceneManager.LoadSceneAsync(sceneName);
    }
    void ResetScene()
    {
        _portalNumber = 3;
        EnergyAndHealthManager.Instance.FillLives();
        EnergyAndHealthManager.Instance.ResetEnergy();
        EnergyAndHealthManager.Instance.IncreaseEnergy(1);
    }
}
