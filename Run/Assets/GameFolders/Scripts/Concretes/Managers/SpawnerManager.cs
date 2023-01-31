using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : Lines
{
   
    [SerializeField] float _maxSpawnTime;
    [SerializeField] float _minSpawnTime;
    [SerializeField] [Range(0,2)] int _lineNumber;
    [SerializeField] bool IsObstacle;
    float _randomSpawnTime;
    float _currentSpawnTime;
    private void OnEnable()
    {
        if(IsObstacle)
        {
            SetLine(_lineNumber);
            GetInTheLine(_lineNumber);
        }

        GetRandomSpawnTime();
    }
    private void Update()
    {
        _currentSpawnTime += Time.deltaTime;    
        if(_currentSpawnTime>_randomSpawnTime)
        {
            Spawn();
            GetRandomSpawnTime();
        }
    }

    private void Spawn()
    {
        ObstacleController newObs = ObstaclePoolManager.Instance.GetPool();
        newObs.transform.parent = this.transform;
        newObs.transform.position = this.transform.position;
        newObs.gameObject.SetActive(true);
    }
    private void GetRandomSpawnTime()
    {
        _currentSpawnTime = 0f;
        _randomSpawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);
    }
}
