using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirMovement   // VerticalMovement?
{
    Rigidbody _rigidbody;
    public AirMovement(PlayerController player)
    {
        _rigidbody = player.GetComponent<Rigidbody>();
    }
    public bool IsOnGround { get =>  _rigidbody.position.y <0.05f; } //velocity control doesn't work because of the falling
    public bool IsFalling { get => _rigidbody.velocity.y < 0f; }
    public void Jump(float force)
    {
        if (_rigidbody.velocity.y != 0) { return; }
        _rigidbody.AddForce(Vector3.up * Time.fixedDeltaTime * force);
    }
    public void GroundPound(float force)
    {
        if (_rigidbody.velocity.y == 0) { return; }
        _rigidbody.velocity= Vector3.zero;
        _rigidbody.AddForce(Vector3.down* Time.fixedDeltaTime * force);
        
    }
    

}
