using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public void YesButton()
    {
        GameManager.Instance.ReLoadScene();
    }
    public void NoButton()
    {

        Application.Quit();
       // GameManager.Instance.LoadScene("Menu");
    }
}
