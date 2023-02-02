using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyPanel : MonoBehaviour
{
    public void EasyButton()
    {
        EnergyAndHealthManager.Instance.SetMaxHealthAndMaxEnergy(4, 4);
        GameManager.Instance.LoadScene("Game");
    }
    public void NormalButton()
    {
        EnergyAndHealthManager.Instance.SetMaxHealthAndMaxEnergy(3, 6);
        GameManager.Instance.LoadScene("GameNormal");
    }
    public void HardButton()
    {
        EnergyAndHealthManager.Instance.SetMaxHealthAndMaxEnergy(3, 8);
        GameManager.Instance.LoadScene("GameHard");
    }
    
}
