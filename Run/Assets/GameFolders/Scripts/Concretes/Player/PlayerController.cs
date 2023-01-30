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
    BoxCollider _collider;

    bool _jumped;
    bool _moveDown;
    bool _moveRight;   //prevents line increasing while moving between lines + also player can cancel the line movement.
    private bool _isDead = false;

    private void Awake()
    {
        _move = new AirMovement(this);
        _input = new InputReader(GetComponent<PlayerInput>());
        _anim = GetComponentInChildren<Animator>();
        _collider = GetComponent<BoxCollider>();
    }
    private void OnEnable()
    {
        SetLine(1);
    }

    void Update()
    {
        if (_isDead) return;
        HandleInputs();
        if (_move.IsOnGround)
        {
            _anim.SetBool("IsOnGround", true);
            _anim.SetBool("IsFalling", false);
            _anim.SetBool("IsJumped", false);
        }
        else if(_move.IsFalling)
        {
            _anim.SetBool("IsFalling",true);
            _anim.SetBool("IsJumped", false);
        }
        else
        {
            _anim.SetBool("IsFalling", false);
            _anim.SetBool("IsOnGround", false);

        }
 
    }
    private void FixedUpdate()
    {
        if (_jumped)
        {
            _move.Jump(jumpForce);
            _anim.SetBool("IsJumped",true);
            _anim.SetBool("IsRolled", false);
            _jumped = false;
            _moveDown = false;    //priority for jump, otherwise stuttering in case of jump + movedown
        }
        if (_moveDown)
        {
            _move.GroundPound(jumpForce);
            _moveDown = false;
            Debug.Log("moveDown");
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
        if (_input.MoveRight && !_input.MoveLeft)
        {
            MoveRight();
        }
        if (_input.MoveLeft && !_input.MoveRight)
        {
            MoveLeft();
        }
        if (_input.Jump)
        {
            _jumped = true;
        }
        if (_input.MoveDown && !_input.Jump)
        {
            _moveDown = true;
            _anim.SetBool("IsRolled",true);
        }     
        else
        {
            if(_move.IsOnGround && !_jumped)
            _anim.SetBool("IsRolled", false);
        }
    }
    private void MoveRight()
    {
        if (IsInLine || !_moveRight)
        {
            LineIncrease();
            _moveRight = true;
        }
    }
    private void MoveLeft()
    {
        if (IsInLine || _moveRight)
        {
            LineDecrease();
            _moveRight = false;
        }      
    }

}
