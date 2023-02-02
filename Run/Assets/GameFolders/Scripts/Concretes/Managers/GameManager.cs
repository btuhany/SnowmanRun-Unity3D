using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    int _portalNumber = 3;
    void Awake()
    {
        SingletonThisObject(this);
    }
    public void StopGame()
    {
        Time.timeScale = 0;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    
    public void PortalDestroyed()
    {
        _portalNumber--;
        if (_portalNumber == 0)
            GameOver();
    }

    public void GameOver()
    {
        throw new NotImplementedException();
    }
}
