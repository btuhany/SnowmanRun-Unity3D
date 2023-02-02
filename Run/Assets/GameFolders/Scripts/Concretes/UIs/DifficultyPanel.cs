using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyPanel : MonoBehaviour
{
    public void EasyButton()
    {
        GameManager.Instance.LoadScene("Game");
    }
    public void NormalButton()
    {
        GameManager.Instance.LoadScene("GameNormal");
    }
    public void HardButton()
    {
        GameManager.Instance.LoadScene("GameHard");
    }

}
