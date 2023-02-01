using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyAndHealthManager : SingletonMonoBehaviour<EnergyAndHealthManager>
{
    [SerializeField] int _maxEnergy;
    [SerializeField] int _minEnergyToFire;
    [SerializeField] int _maxHealth;
    float _currentEnergy = 0;
    public bool IsEnergyFull => _currentEnergy >= _maxEnergy;
    public bool IsDead => _maxHealth <= 0;
    public bool IsThereEnergy => _currentEnergy >= _minEnergyToFire;
    private void Awake()
    {
        SingletonThisObject(this);
    }
    private void Update()
    {
        Debug.Log("Energy: " + _currentEnergy);
        Debug.Log("Health: " +_maxHealth);
    }
    public void IncreaseEnergy(int energy)
    {
        _currentEnergy+= energy;
        if(_currentEnergy > _maxEnergy)
            _currentEnergy = _maxEnergy;
    }
    public void DecreaseEnergy(int energy)
    {
        _currentEnergy -= energy;
        if(_currentEnergy<0)
            _currentEnergy=0;
    }
    public void DecreaseHealth(int health)
    {
        _maxHealth -= health;
        if(_maxHealth<=0)
        {
            _maxHealth = 0;
            Time.timeScale = 0.1f;
        }
            
    }
}
