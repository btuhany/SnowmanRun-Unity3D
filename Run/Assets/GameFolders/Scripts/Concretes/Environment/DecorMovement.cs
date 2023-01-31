using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorMovement : MonoBehaviour
{
    const float _moveSpeed = 10;

    private void Update()
    {
        transform.position += Vector3.back * Time.deltaTime * _moveSpeed;
    }
}
