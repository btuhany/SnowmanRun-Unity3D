using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMovement : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    PlayerController _playerController;
    Rigidbody _rb;
    
    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
            ChangeLine();
    }

    void ChangeLine()
    {
          Vector3 pos = new Vector3 ( 0f,_rb.position.y, _rb.position.z );
          _rb.position = Vector3.MoveTowards(_rb.position, pos + _playerController.GetLine(), Time.fixedDeltaTime * _moveSpeed);
    }
    

}
