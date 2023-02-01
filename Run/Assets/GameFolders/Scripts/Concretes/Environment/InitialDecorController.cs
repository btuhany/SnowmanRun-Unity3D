using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialDecorController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 10;
    [SerializeField] float _minZ;

    private void Update()
    {
        transform.position += Vector3.back * Time.deltaTime * _moveSpeed;
        if (transform.position.z < _minZ) Destroy(this.gameObject);
    }
}
