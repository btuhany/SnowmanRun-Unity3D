using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] ObstacleType _obstacleType;
    [SerializeField] float moveSpeed;
    [SerializeField] private float _minZ;
    VerticalMover _move;
    public ObstacleType ObstacleType => _obstacleType;
    private void Awake()
    {
        _move = new VerticalMover(this.gameObject);
    }
    private void Update()
    {
        if(transform.position.z <_minZ)
        {
            ObstaclePoolManager.Instance.SetPool(this);
        }
    }
    private void FixedUpdate()
    {
        _move.FixedTick(moveSpeed);
    }
    
}
