using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    public void StartButton()
    {

    }
    public void ExitButton()
    {
        GameManager.Instance.ExitGame();
    }
}
