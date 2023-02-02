using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] DifficultyPanel _difficultyPanel;
    [SerializeField] GameObject[] _texts;
    public void StartButton()
    {
        Debug.Log("Start");
        if (_difficultyPanel.gameObject.activeSelf)
        {
            _difficultyPanel.gameObject.SetActive(false);
            _texts[0].gameObject.SetActive(true);
            _texts[1].gameObject.SetActive(true);
        }
            
        else
        {

            _texts[0].gameObject.SetActive(false);
            _texts[1].gameObject.SetActive(false);
            _difficultyPanel.gameObject.SetActive(true);
        }
    }
    public void ExitButton()
    {
        GameManager.Instance.ExitGame();
    }
}
