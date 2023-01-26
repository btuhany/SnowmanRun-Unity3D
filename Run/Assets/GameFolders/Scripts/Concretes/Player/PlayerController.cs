using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : Lines
{
    [SerializeField] float jumpForce;
    RbMovement _move;
    InputReader _input;
    bool _jumped;
    bool _groundPound;
    private void Awake()
    {
        _move = new RbMovement(this);
        _input = new InputReader(GetComponent<PlayerInput>());
    }
    private void Start()
    {
        SetLine(1);
    }

    void Update()
    {
        HandleInputs();
        Debug.Log(_input.Jump);
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
        //if(_input.Jump==1 && !_jumped)
        //{
        //    _jumped = true;
        //}
        Debug.Log(_input.Jump);

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _groundPound = true;
        }
    }
}
