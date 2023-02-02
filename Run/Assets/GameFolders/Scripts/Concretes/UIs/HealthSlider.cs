using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    Slider _slider;
    TextMeshProUGUI _textMesh;
    int _healthAtMax;
    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _textMesh = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Start()
    {
        _slider.maxValue = EnergyAndHealthManager.Instance.MaxHealth;
        _healthAtMax = EnergyAndHealthManager.Instance.MaxHealth;
    }
    private void Update()
    {
        _slider.value = EnergyAndHealthManager.Instance.MaxHealth;
        _textMesh.SetText("HEALTH: " + _slider.value.ToString() + "/" + _healthAtMax.ToString());
    }
}
