using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Could use it with spawner manager with a spawner abstract class.
public class DecorSpawner : MonoBehaviour
{
    
    [SerializeField] float _maxSpawnTime;
    [SerializeField] float _minSpawnTime;
    
   
    float _randomSpawnTime;
    float _currentSpawnTime;
    private void OnEnable()
    {
        GetRandomSpawnTime();
    }
    private void Update()
    {
        _currentSpawnTime += Time.deltaTime;
        if (_currentSpawnTime > _randomSpawnTime)
        {
            Spawn();
            GetRandomSpawnTime();
        }
    }
    private void Spawn()
    {
        int randomNumber = Random.Range(5,8);
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
