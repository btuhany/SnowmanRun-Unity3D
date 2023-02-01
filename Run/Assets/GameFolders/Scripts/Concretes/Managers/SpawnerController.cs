using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : Lines
{
   
    [SerializeField] float _maxSpawnTime;
    [SerializeField] float _minSpawnTime;
    [SerializeField] [Range(0,2)] int _lineNumber;
    float _randomSpawnTime;
    float _currentSpawnTime;

    int _spawnVariationIndex;
    float _spawnVariationTime;

    public bool IsSpawnIndexExceeded => _spawnVariationIndex >= ObstaclePoolManager.Instance.NumberOfObstacles;
    private void OnEnable()
    {
        SetLine(_lineNumber);
        GetInTheLine(_lineNumber);
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

        if (IsSpawnIndexExceeded) return;
        
        if (_spawnVariationTime < Time.time)
        {
            _spawnVariationTime = Time.time + SpawnerManager.Instance.SpawnVariationDelay;
            _spawnVariationIndex++;
        }
      

    }

    private void Spawn()
    {
        int randomNumber = Random.Range(0, _spawnVariationIndex);
        ObstacleType obstacle = (ObstacleType)randomNumber;
        if (!SpawnerManager.Instance.CanSpawn(obstacle))
        {
            Debug.Log("returned");
            return;
            
        }
        ObstacleController newObs = ObstaclePoolManager.Instance.GetPool((ObstacleType)randomNumber);
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
