using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergySlider : MonoBehaviour
{
    Slider _slider;
    TextMeshProUGUI _textMesh;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _textMesh = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Start()
    {
        _slider.maxValue = EnergyAndHealthManager.Instance.MaxEnergy;
    }
    private void Update()
    {
        _slider.value = EnergyAndHealthManager.Instance.CurrentEnergy;
        _textMesh.SetText("SNOWBALL ENERGY: " + _slider.value.ToString() + "/" + _slider.maxValue.ToString());
    }
}
