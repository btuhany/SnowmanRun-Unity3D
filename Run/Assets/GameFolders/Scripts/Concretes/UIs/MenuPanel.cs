using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] DifficultyPanel _difficultyPanel;
    public void StartButton()
    {
        Debug.Log("Start");
        if (_difficultyPanel.gameObject.activeSelf)
            _difficultyPanel.gameObject.SetActive(false);
        else
            _difficultyPanel.gameObject.SetActive(true);
    }
    public void ExitButton()
    {
        GameManager.Instance.ExitGame();
    }
}
