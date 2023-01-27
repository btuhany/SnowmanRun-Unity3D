using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader
{
	PlayerInput _playerInput;
    public bool Jump { get; private set; }
    public bool MoveRight { get; private set; }
    public bool MoveLeft { get; private set; }
    public bool MoveDown { get; private set; }
    public InputReader(PlayerInput playerInput)
	{
		_playerInput = playerInput;
        _playerInput.currentActionMap.actions[0].started += OnJump;
        _playerInput.currentActionMap.actions[0].canceled += OnJump;
        // _playerInput.currentActionMap.actions[1].performed += OnMoveRight;
        _playerInput.currentActionMap.actions[1].started+= OnMoveRight;
        _playerInput.currentActionMap.actions[1].canceled+= OnMoveRight;

        //_playerInput.currentActionMap.actions[2].performed += OnMoveLeft;
        _playerInput.currentActionMap.actions[2].started += OnMoveLeft;
        _playerInput.currentActionMap.actions[2].canceled += OnMoveLeft;

        _playerInput.currentActionMap.actions[3].started += OnMoveDown;
        _playerInput.currentActionMap.actions[3].canceled += OnMoveDown;
    }

    private void OnMoveDown(InputAction.CallbackContext context)
    {
        MoveDown = context.ReadValueAsButton();
    }

    private void OnMoveLeft(InputAction.CallbackContext context)
    {
        MoveLeft = context.ReadValueAsButton();
    }

    private void OnMoveRight(InputAction.CallbackContext context)
    {
        MoveRight = context.ReadValueAsButton();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        Jump = context.ReadValueAsButton();
    }
}
