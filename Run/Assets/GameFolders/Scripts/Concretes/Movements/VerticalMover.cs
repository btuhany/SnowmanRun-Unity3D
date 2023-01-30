using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMover
{
    Rigidbody _rb;
    public VerticalMover(GameObject gameObject)
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }
    public void FixedTick(float moveSpeed = 1)
    {
        _rb.MovePosition(_rb.position + Vector3.back * moveSpeed * Time.deltaTime);
    }

}
