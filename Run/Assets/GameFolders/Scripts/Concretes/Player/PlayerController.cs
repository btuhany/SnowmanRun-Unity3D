using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : Lines
{
    [SerializeField] float jumpForce;
    RbMovement _move;
    InputReader _input;
    
    bool _jumped;
    bool _moveDown;
   // bool _groundPound;

    bool moveRight;
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
        if(_moveDown)
        {
            _move.GroundPound(jumpForce);
            _moveDown = false;
        }
    }
    private void HandleInputs()
    {
        if (_input.Jump)
        {
            _jumped = true;
        }
        if(_input.MoveDown)
        {
            transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            _moveDown = true;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
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
    }
    private void MoveLeft()
    {
        LineDecrease();
        moveRight = false;
    }
    
}
