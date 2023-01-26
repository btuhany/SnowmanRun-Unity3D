using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMovement : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    PlayerController _playerController;
    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        LineControl();
    }

    void LineControl()
    {
        transform.position = Vector3.MoveTowards(transform.position, _playerController.GetLine(), Time.deltaTime * _moveSpeed);
    }
}
