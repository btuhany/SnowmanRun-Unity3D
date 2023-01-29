using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : Lines
{
    [SerializeField] float jumpForce;
    AirMovement _move;
    InputReader _input;
    
    bool _jumped;
    bool _moveDown;
   // bool _groundPound;

    bool moveRight;
    private bool _isDead = false;

    private void Awake()
    {
        _move = new AirMovement(this);
        _input = new InputReader(GetComponent<PlayerInput>());
    }
    private void Start()
    {
        
        SetLine(1);
    }

    void Update()
    {
        if (_isDead) return;
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
        Debug.Log(IsInLine);
    }
    private void FixedUpdate()
    {
        
        if(_jumped)
        {
            _move.Jump(jumpForce);
            _jumped = false;
            _moveDown = false;    //priority for jump
            
        }
        if(_moveDown)
        {
            _move.GroundPound(jumpForce);
            
            _moveDown = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            _isDead=true;
            GameManager.Instance.StopGame();
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
            //transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            _moveDown = true;
        }
        else
        {
           //transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

    }
    private void HandleLineInputs()
    {
        if (_input.MoveRight && !_input.MoveLeft)
        {
            MoveRight();
            Debug.Log("RightLineInput");
        }
        else if (_input.MoveLeft && !_input.MoveRight)
        {
            MoveLeft();
            Debug.Log("LeftLineInput");
        }
    }
    private void HandleInGapInputs()
    {
        if (_input.MoveRight && !_input.MoveLeft && !moveRight)
        {
            MoveRight();
            Debug.Log("RightGapInput");
        }
        if (_input.MoveLeft && !_input.MoveRight && moveRight)
        {
            MoveLeft();
            Debug.Log("LeftGapInput");
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
