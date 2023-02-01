using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxManager : MonoBehaviour
{

    [SerializeField] float _dayNightCycleSpeed;
    float _transitionValue;
    bool IsNight;

    private void Start()
    {
        RenderSettings.skybox.SetFloat("_CubemapTransition", _transitionValue);
    }
    private void Update()
    {
        if (IsNight)
        {
            _transitionValue -= Time.deltaTime * _dayNightCycleSpeed;
            if(_transitionValue <= 0) { IsNight= false; }
        }
        else
        {
            _transitionValue += Time.deltaTime * _dayNightCycleSpeed;
            if (_transitionValue >= 1) { IsNight = true; }
        }

        

        RenderSettings.skybox.SetFloat("_CubemapTransition", _transitionValue);

        
        
    }
}
