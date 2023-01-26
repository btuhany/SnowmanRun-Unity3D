using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader
{
	PlayerInput _playerInput;
    public float Jump { get; private set; }
	public InputReader(PlayerInput playerInput)
	{
		_playerInput = playerInput;
        _playerInput.currentActionMap.actions[0].started += OnJump;
        _playerInput.currentActionMap.actions[0].canceled += OnJump;
        

    }

    private void OnJump(InputAction.CallbackContext context)
    {
        Jump = context.ReadValue<float>();
    }
}
