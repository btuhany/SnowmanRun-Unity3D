using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : SingletonMonoBehaviour<SpawnerManager>
{
    //[SerializeField] int _jumpCubeObstacleLimit;
    //[SerializeField] int _rollCubeObstacleLimit;
    //[SerializeField] int _longCubeObstacleLimit;
    //[SerializeField] int _shortCubeObstacleLimit;
    //[SerializeField] int _energySphereCubeObstacleLimit;
    [SerializeField] int[] _obstacleLimits = new int[8];
  

    Dictionary<ObstacleType, int> _obstacleNumbers = new Dictionary<ObstacleType, int>();
 
    private void Awake()
    {
        SingletonThisObject(this);
    }
    private void Update()
    {
        Debug.Log("jumpcube" + _obstacleNumbers[ObstacleType.JumpCube]);
        Debug.Log("rollcube" + _obstacleNumbers[ObstacleType.RollCube]);
        Debug.Log("shortcube" + _obstacleNumbers[ObstacleType.ShortCube]);
        Debug.Log("longcube" + _obstacleNumbers[ObstacleType.LongCube]);
        Debug.Log("energysphere" + _obstacleNumbers[ObstacleType.EnergySphere]);
    }
    public void NewObstacle(ObstacleController obstacle)
    {
        if(!_obstacleNumbers.ContainsKey(obstacle.ObstacleType))
        {
            _obstacleNumbers.Add(obstacle.ObstacleType, 0);
        }
        else
        {
            _obstacleNumbers[obstacle.ObstacleType]++;
        }
    }
    public void DeleteObstacle(ObstacleController obstacle)
    {
        if (!_obstacleNumbers.ContainsKey(obstacle.ObstacleType))
        {
            return;
        }
        else
        {
            _obstacleNumbers[obstacle.ObstacleType]--;
            if(_obstacleNumbers[obstacle.ObstacleType] < 0)
                _obstacleNumbers[obstacle.ObstacleType] = 0;
        }
    }
    public bool CanSpawn(ObstacleType obstacle)
    {
        if (_obstacleNumbers[obstacle] >= _obstacleLimits[(int)obstacle])
            return false;
        else
            return true;
    }
}
