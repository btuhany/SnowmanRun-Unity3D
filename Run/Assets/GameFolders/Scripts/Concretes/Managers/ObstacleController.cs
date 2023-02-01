using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] ObstacleType _obstacleType;
    [SerializeField] float _moveSpeed;
    [SerializeField] private float _minZ;
    [SerializeField] private bool _isDecore;
    VerticalMover _move;

    
    public ObstacleType ObstacleType => _obstacleType;
    private void Awake()
    {
        if (_isDecore) return;
        _move = new VerticalMover(this.gameObject);
    }
    
    private void OnEnable()
    {
        SpawnerManager.Instance.NewObstacle(this);
    }
    private void OnDisable()
    {
        SpawnerManager.Instance.DeleteObstacle(this);
    }
    private void Update()
    {
        if(transform.position.z <_minZ)
        {
            ObstaclePoolManager.Instance.SetPool(this);
        }
        if(_isDecore)
        {
            transform.position += Vector3.back * Time.deltaTime * _moveSpeed;
        }
        
    }
    
    private void FixedUpdate()
    {
        if (_isDecore) return;
        _move.FixedTick(_moveSpeed);
    }
    
    
}
