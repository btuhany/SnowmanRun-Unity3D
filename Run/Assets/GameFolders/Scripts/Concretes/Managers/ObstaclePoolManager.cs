using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePoolManager : SingletonMonoBehaviour<ObstaclePoolManager>
{
    [SerializeField] ObstacleController _obstaclePrefab;

    Queue<ObstacleController> _obstacles = new Queue<ObstacleController> ();
    private void Awake()
    {
        SingletonThisObject(this);

    }

    private void Start()
    {
        InitalizePool();
    }

    private void InitalizePool()
    {
        for(int i = 0; i < 10; i++)
        {
            ObstacleController newObstacle = Instantiate(_obstaclePrefab);
            newObstacle.gameObject.SetActive(false);
            newObstacle.transform.parent = this.transform;
            _obstacles.Enqueue(newObstacle);
        }
    }

    public void SetPool(ObstacleController obstacle)
    {
        obstacle.gameObject.SetActive(false);
        obstacle.transform.parent = this.transform;
        _obstacles.Enqueue (obstacle);
    }
    public ObstacleController GetPool()
    {
        if(_obstacles.Count ==0)
        {
            InitalizePool();
        }
        return _obstacles.Dequeue();
    }

}

