using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement   // VerticalMovement?
{
    Rigidbody _rigidbody;
    BoxCollider _collider;

    private float _colliderChangedTime;
    public Movement(PlayerController player)
    {
        _rigidbody = player.GetComponent<Rigidbody>();
        _collider= player.GetComponent<BoxCollider>();
    }
    public bool IsOnGround { get =>  _rigidbody.position.y <0.14f; } //velocity control doesn't work because of the falling
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
    public void RollCollider(bool rollCollider, float cooldown = 0.6f)
    {
        if (rollCollider)
        {
            _collider.size = new Vector3(1.74f, 2.05f, 0.74f);
            _collider.center = new Vector3(0f, 0.89f, 0.04f);
            _colliderChangedTime = Time.time;
        }
        else
        {
            if (Time.time - _colliderChangedTime < cooldown)
                return;
            _collider.center = new Vector3(0, 1.68f, 0.043f);
            _collider.size = new Vector3(1.746f, 3.63f, 0.747f);
        }
    }

}
