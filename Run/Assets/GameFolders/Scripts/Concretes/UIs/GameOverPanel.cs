using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public void YesButton()
    {
        GameManager.Instance.ReLoadScene();
    }
    public void NoButton()
    {
        GameManager.Instance.LoadScene("Menu");
    }
}
