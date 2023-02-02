using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolController : MonoBehaviour
{
    [SerializeField] SpawnerController _spawner;
    [SerializeField] PlayerController _player;
    [SerializeField] float _yOffSet;
    [SerializeField] float _speed = 1f;
     Vector3 _direction;
    float _factor;
    private void Start()
    {
       _direction = new Vector3(0,_player.gameObject.transform.position.y - _spawner.gameObject.transform.position.y + _yOffSet, _player.gameObject.transform.position.z - _spawner.gameObject.transform.position.z);
    }
    private void Update()
    {
        if (_spawner.gameObject.activeSelf) return;
        //sin(2*pi*T*speed) 
        
        float sinWave = Mathf.Sin(Mathf.PI * Time.time * _speed);
        _factor = Mathf.Abs(sinWave);

        Vector3 startPosition = new Vector3(_spawner.gameObject.transform.position.x , 2,  _spawner.gameObject.transform.position.z);
        Vector3 offset = _direction * _factor;

        transform.position = offset + startPosition;



    }
}
