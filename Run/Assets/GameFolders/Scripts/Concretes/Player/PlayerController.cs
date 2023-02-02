using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : Lines
{
    [SerializeField] SnowballController snowBall;
    [SerializeField] SnowballController snowBallBig;
    
    [SerializeField] float jumpAndRollForce;
    Movement _move;
    InputReader _input;
    Animator _anim;
    


    bool _jumped;
    bool _moveDown;
    bool _moveRight;   //prevents line increasing while moving between lines + also player can cancel the line movement.
    


    private void Awake()
    {
        _move = new Movement(this);
        _input = new InputReader(GetComponent<PlayerInput>());
        _anim = GetComponentInChildren<Animator>();
        

    }
    private void OnEnable()
    {
        SetLine(1);
    }

    void Update()
    {
        if (EnergyAndHealthManager.Instance.IsDead) return;
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
            _move.Jump(jumpAndRollForce*100);
            _anim.SetBool("IsJumped",true);
            _anim.SetBool("IsRolled", false);
            _jumped = false;
            _moveDown = false;    //priority for jump, otherwise stuttering in case of jump + movedown
            
        }
        if (_moveDown)
        {
            _move.Roll(jumpAndRollForce*100);
            _moveDown = false;
          
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
        if(Input.GetKeyDown(KeyCode.F) && EnergyAndHealthManager.Instance.IsThereEnergy)
        {
            UseEnergy();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.GameOver();
        }
        if (_input.MoveDown && !_input.Jump)
        {
            _moveDown = true;
            _anim.SetBool("IsRolled",true);
            _anim.SetBool("IsFalling", false) ;
        }     
        else
        {
            if (_move.IsOnGround && !_jumped)
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
    private void UseEnergy()
    {
        if (EnergyAndHealthManager.Instance.IsEnergyFull)
            ThrowSnowBall(2);
        else
            ThrowSnowBall(1);
        _anim.SetTrigger("IsFire");
    }
    private void ThrowSnowBall(int snowBallNumber)
    {
        Vector3 tempVect = new Vector3(transform.position.x, transform.position.y + 1.6f, transform.position.z + 5f);
        if (snowBallNumber == 1)
        {   
            Instantiate(snowBall, tempVect, transform.rotation);
            EnergyAndHealthManager.Instance.DecreaseEnergy(1);
        }
        else if(snowBallNumber ==2)
        {
            Instantiate(snowBallBig, tempVect, transform.rotation);
            EnergyAndHealthManager.Instance.ResetEnergy();
        }
    }
    
}
