using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : Lines
{
   
    [SerializeField] float _maxSpawnTime;
    [SerializeField] float _minSpawnTime;
    [SerializeField] Vector3 _spawnOffset; 
    [SerializeField] [Range(0,2)] int _lineNumber;
    float _randomSpawnTime;
    float _currentSpawnTime;




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

      
        
 
      

    }

    private void Spawn()
    {
        int randNum = Random.Range(0, 100);
        int randIndex = 0; // Random.Range(0, _spawnVariationIndex);
        if (randNum<100 && randNum>=70)
        {
            randIndex = 4;
        }
        else if(randNum>= 48)
        {
            randIndex = 1;
        }
        else if(randNum>=25)
        {
            randIndex = 0;
        }
        else if(randNum>= 10)
        {
            randIndex = 3;
        }
        else
        {
            randIndex = 2;
        }
        

        ObstacleType obstacle = (ObstacleType)randIndex;
        if (!SpawnerManager.Instance.CanSpawn(obstacle))
        {
            Debug.Log("returned");
            return;
            
        }
        ObstacleController newObs = ObstaclePoolManager.Instance.GetPool((ObstacleType)randIndex);
        newObs.transform.parent = this.transform;
        newObs.transform.position = this.transform.position + _spawnOffset;
        newObs.gameObject.SetActive(true);
    }
    private void GetRandomSpawnTime()
    {
        _currentSpawnTime = 0f;
        _randomSpawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);
    }

}
