using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyAndHealthManager : SingletonMonoBehaviour<EnergyAndHealthManager>
{
    [SerializeField] int _maxEnergy;
    [SerializeField] int _minEnergyToFire;
    [SerializeField] int _maxHealth;
    [SerializeField] int _invulnerableTime;
    int _liveAtStart;
    float _currentEnergy = 0;
    private bool _invulnerable;
    public bool IsEnergyFull => _currentEnergy >= _maxEnergy;
    public bool IsDead => _maxHealth <= 0;
    public bool IsThereEnergy => _currentEnergy >= _minEnergyToFire;

    public int MaxEnergy { get => _maxEnergy; set => _maxEnergy = value; }
    public float CurrentEnergy { get => _currentEnergy; set => _currentEnergy = value; }
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }

    private void Awake()
    {
        SingletonThisObject(this);
    }
    private void Start()
    {
        _liveAtStart = _maxHealth;
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
        if (_invulnerable) return;
        _maxHealth -= health;
        if (_maxHealth<=0)
        {
            _maxHealth = 0;
            GameManager.Instance.GameOver();
        }
        else
        {
            StartCoroutine(HealthCoolDown());
        }
    }
    public void FillLives()
    {
        _maxHealth = _liveAtStart;
    }
    IEnumerator HealthCoolDown()
    {
        _invulnerable = true;
        yield return new WaitForSeconds(_invulnerableTime);
        _invulnerable = false;
    }
}
