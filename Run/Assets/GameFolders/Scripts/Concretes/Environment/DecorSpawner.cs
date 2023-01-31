using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Could use it with spawner manager with a spawner abstract class.
public class DecorSpawner : MonoBehaviour
{
    [SerializeField] DecorMovement _decorPrefab;
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

        Instantiate(_decorPrefab, transform.position, Quaternion.Euler(0, 0, 0));
    }
    private void GetRandomSpawnTime()
    {
        _currentSpawnTime = 0f;
        _randomSpawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);
    }
}
