using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    int _portalNumber = 3;
    public event System.Action OnGameOver;
    void Awake()
    {
        SingletonThisObject(this);
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        OnGameOver?.Invoke();
    }
    public void ExitGame()
    {
        Debug.Log("Exit clicked");
        Application.Quit();
    }
    public void LoadScene(string sceneName)
    {
        Debug.Log("hello");
        StartCoroutine(LeadSceneAsync(sceneName));
        
    }
    public void PortalDestroyed()
    {
        _portalNumber--;
        if (_portalNumber == 0)
            GameOver();
    }
    private IEnumerator LeadSceneAsync(string sceneName)
    {
        Time.timeScale = 1f;
        yield return SceneManager.LoadSceneAsync(sceneName);
    }
}
