using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] private float _maxLifeTime;
    VerticalMover _move;
    public float _currentLifeTime;

    private void Awake()
    {
        _move = new VerticalMover(this.gameObject);
    }
    private void Update()
    {
        _currentLifeTime += Time.deltaTime;
        if(_currentLifeTime>_maxLifeTime)
        {
            _currentLifeTime = 0f;
            Destroy(this.gameObject);
        }
        if (transform.position.z < -1f)
        {
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        _move.FixedTick(moveSpeed);
    }

}
