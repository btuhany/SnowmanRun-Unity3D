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
  //  bool _isOnGround;
    bool _jumped;
   // bool _groundPound;

    bool moveRight;
    private void Awake()
    {
        _move = new RbMovement(this);
        _input = new InputReader(GetComponent<PlayerInput>());
    }
    private void Start()
    {
       // _isOnGround = true;
        SetLine(1);
    }

    void Update()
    {
        HandleInputs();
        if(IsInLine)
        {
            HandleLineInputs();   //Player can hold the button and change line
                                  
        }
        else
        {
            HandleInGapInputs(); //Player can hold the button and change line
                                 //while also cancel or adjust the line change action.
        }
    }
    private void FixedUpdate()
    {
        if(_jumped)
        {
            _move.Jump(jumpForce);
            _jumped = false;
        }
    }
    private void HandleInputs()
    {
        if (_input.Jump)
        {
            _jumped = true;
        }

    }
    private void HandleLineInputs()
    {
        if (_input.MoveRight && !_input.MoveLeft)
        {
            MoveRight();
        }
        else if (_input.MoveLeft && !_input.MoveRight)
        {
            MoveLeft();
        }
    }
    private void HandleInGapInputs()
    {
        if (_input.MoveRight && !_input.MoveLeft && !moveRight)
        {
            MoveRight();
        }
        if (_input.MoveLeft && !_input.MoveRight && moveRight)
        {
            MoveLeft();
        }
    }
    private void MoveRight()
    {
        LineIncrease();
        moveRight = true;
        return;
    }
    private void MoveLeft()
    {
        LineDecrease();
        moveRight = false;
        return;
    }
    
}
