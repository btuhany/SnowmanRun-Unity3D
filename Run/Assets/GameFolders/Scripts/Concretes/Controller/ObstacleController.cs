using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    Rigidbody _rb;
    private void Awake()
    {
        _rb = GetComponentInChildren<Rigidbody>();
    }
    void Update()
    {
        transform.position += Vector3.back * moveSpeed * Time.deltaTime;
    }

}
