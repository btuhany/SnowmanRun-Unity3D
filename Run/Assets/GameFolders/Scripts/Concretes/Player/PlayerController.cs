using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Lines
{
    [SerializeField] float jumpForce;
    RbMovement _move;
    bool _jumped;
    bool _groundPound;
    private void Awake()
    {
        _move = new RbMovement(this);
    }
    private void Start()
    {
        SetLine(1);
    }

    void Update()
    {
        HandleInputs();
    }
    private void FixedUpdate()
    {
        if(_jumped)
        {
            _move.Jump(jumpForce);
            _jumped = false;
        }
        if (_groundPound)
        {
            _move.GroundPound(jumpForce);
            _groundPound= false;
        }
    }
    private void HandleInputs()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            LineIncrease();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LineDecrease();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _jumped = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _groundPound = true;
        }
    }
}
