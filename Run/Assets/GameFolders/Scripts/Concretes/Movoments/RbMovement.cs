using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RbMovement   // VerticalMovement?
{
    Rigidbody _rigidbody;
    public RbMovement(PlayerController player)
    {
        _rigidbody = player.GetComponent<Rigidbody>();
    }
    public void Jump(float force)
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(Vector3.up * Time.fixedDeltaTime * force);
    }
    public void GroundPound(float force)
    {
        _rigidbody.velocity= Vector3.zero;
        _rigidbody.AddForce(Vector3.down* Time.fixedDeltaTime * force);
    }

}
