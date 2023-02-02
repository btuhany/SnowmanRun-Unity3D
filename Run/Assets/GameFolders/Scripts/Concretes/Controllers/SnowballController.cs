using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballController : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] int _maxEnemyDestroyLimit;
    [SerializeField] float _killAtMaxZ;

    [SerializeField] bool IsBig;
    int _destroyedEnemyCount;
    Rigidbody _rb;
    private void Awake()
    {
        _rb=GetComponent<Rigidbody>();
    }
    private void Update()
    {
        _rb.position += Vector3.forward * Time.deltaTime * _moveSpeed;
        if(_rb.position.z>_killAtMaxZ)
            Destroy(this.gameObject);
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
        if (IsBig && collision.gameObject.tag == "spawner")
        {
            
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
            GameManager.Instance.PortalDestroyed();
        }

    }

  
}
