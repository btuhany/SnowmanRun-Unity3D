using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePoolManager : SingletonMonoBehaviour<ObstaclePoolManager>
{
    [SerializeField] ObstacleController[] _obstaclePrefabs;
    

    Dictionary<ObstacleType, Queue<ObstacleController>> _obstaclesDictionary = new Dictionary<ObstacleType, Queue<ObstacleController>>();

    
    public int NumberOfObstacles { get => _obstaclePrefabs.Length; }

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
        for(int i = 0; i < _obstaclePrefabs.Length; i++) //for each prefab create a queue and add it to the dictionary
        {
            Queue<ObstacleController> obstacleQueue = new Queue<ObstacleController> ();

            for (int j = 0; j < 8; j++)
            {
                ObstacleController newObstacle = Instantiate(_obstaclePrefabs[i]);
                newObstacle.gameObject.SetActive(false);
                newObstacle.transform.parent = this.transform;
                obstacleQueue.Enqueue (newObstacle);
            }
            _obstaclesDictionary.Add((ObstacleType)i, obstacleQueue);
        }
    }

    public void SetPool(ObstacleController obstacle)
    {
        obstacle.gameObject.SetActive(false);
        obstacle.transform.parent = this.transform;

        Queue<ObstacleController> obstacleQueue = _obstaclesDictionary[obstacle.ObstacleType];
        obstacleQueue.Enqueue(obstacle);
    }
    public ObstacleController GetPool(ObstacleType obstacleType)
    {
        Queue<ObstacleController> obstacleQueue = _obstaclesDictionary[obstacleType];
        if(obstacleQueue.Count == 0)
        {
                ObstacleController newObstacle = Instantiate(_obstaclePrefabs[(int)obstacleType]);
                obstacleQueue.Enqueue(newObstacle);
        }
        return obstacleQueue.Dequeue();
    }

}

