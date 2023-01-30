using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
  
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

}
