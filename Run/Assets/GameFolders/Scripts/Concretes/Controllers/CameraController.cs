using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;
    [SerializeField] float _followSpeed;
    Vector3 _offset;
    private void Start()
    {
        _offset = transform.position - _playerTransform.position;
    }
    private void LateUpdate()
    {
        
        transform.position = Vector3.Lerp(transform.position, _playerTransform.position + _offset,Time.deltaTime*_followSpeed);
    }
}
