using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballController : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] int _maxEnemyDestroyLimit;
    int _destroyedEnemyCount;
    private void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * _moveSpeed;  
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "enemy")
        {
            ObstaclePoolManager.Instance.SetPool(collision.gameObject.GetComponent<ObstacleController>());     
            _destroyedEnemyCount++;
        }
        if (_destroyedEnemyCount == _maxEnemyDestroyLimit)
            Destroy(this.gameObject);


    }
}
