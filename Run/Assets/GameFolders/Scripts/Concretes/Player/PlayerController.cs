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
    Animator _anim;

    bool _jumped;
    bool _moveDown;
    bool moveRight;   //prevents line increasing while moving between lines + also player can cancel the line movement.
    private bool _isDead = false;

    private void Awake()
    {
        _move = new AirMovement(this);
        _input = new InputReader(GetComponent<PlayerInput>());
        _anim = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        SetLine(1);
    }

    void Update()
    {
        if (_isDead) return;
        HandleInputs();
        //if (IsInLine)
        //{
        //    HandleLineInputs();     //Player can hold the button and change line
        //}
        //else
        {
            HandleInGapInputs();    //Player can hold the button and change line
                                    //while also cancel or adjust the line change action.
        }
    }
    private void FixedUpdate()
    {

        if (_jumped)
        {
            _move.Jump(jumpForce);
            _jumped = false;
            _moveDown = false;    //priority for jump

        }
        if (_moveDown)
        {
            _move.GroundPound(jumpForce);

            _moveDown = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            _isDead = true;
            GameManager.Instance.StopGame();
        }
    }
    private void HandleInputs()
    {
        if (_input.Jump)
        {
            _jumped = true;
        }
        if (_input.MoveDown)
        {
            _moveDown = true;
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
    private void HandleInGapInputs() //prevents line increasing while moving between lines + also player can cancel the line movement.
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
