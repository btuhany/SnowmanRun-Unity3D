using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxManager : MonoBehaviour
{

    [SerializeField] float _skyRotationSpeed;
    float _transitionValue;
    bool IsNight;

    private void Update()
    {
        if (IsNight)
        {
            _transitionValue -= Time.deltaTime * _skyRotationSpeed;
            if(_transitionValue <= 0) { IsNight= false; }
        }
        else
        {
            _transitionValue += Time.deltaTime * _skyRotationSpeed;
            if (_transitionValue >= 1) { IsNight = true; }
        }

        

        RenderSettings.skybox.SetFloat("_CubemapTransition", _transitionValue);

        
        
    }
}
