using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement   // VerticalMovement?
{
    Rigidbody _rigidbody;
    ColliderManagment _collider;

    public Movement(PlayerController player)
    {
        _rigidbody = player.GetComponent<Rigidbody>();
        _collider= player.GetComponent<ColliderManagment>();

    }
    public bool IsOnGround { get =>  _rigidbody.position.y <0.14f; } //velocity control doesn't work because of the falling
    public bool IsFalling { get => _rigidbody.velocity.y < 0f; }
    public void Jump(float force)
    {
        if (_rigidbody.velocity.y != 0) { return; }
        _rigidbody.AddForce(Vector3.up * Time.fixedDeltaTime * force );
        _collider.JumpState();
       
    }
    public void Roll(float force)
    {
        _collider.RollState();
        if (_rigidbody.velocity.y == 0) { return; }
        _rigidbody.velocity= Vector3.zero;
        _rigidbody.AddForce(Vector3.down* Time.fixedDeltaTime * force);
    
   
    }
 

}
