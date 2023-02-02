using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManagement : MonoBehaviour
{
    [SerializeField] float _colliderCooldown;
    [SerializeField] Vector3 _jumpColliderCenter;
    [SerializeField] Vector3 _jumpColliderSize;
    [SerializeField] Vector3 _rollColliderCenter;
    [SerializeField] Vector3 _rollColliderSize;
    [SerializeField] GameObject _brokenHeartFX;
    PlayerController _player;
    BoxCollider _collider;

    Vector3 _colliderCenterAtStart;
    Vector3 _colliderSizeAtStart;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
        
    }
    private void OnEnable()
    {
        _colliderCenterAtStart = _collider.center;
        _colliderSizeAtStart = _collider.size;
    }
    private void OnCollisionEnter(Collision collision)
    {
        ObstacleController obstacle = collision.gameObject.GetComponent<ObstacleController>();
        if (obstacle == null) return;
        if (collision.gameObject.tag == "enemy")
        {
            // _isDead = true;
            _brokenHeartFX.gameObject.SetActive(true);
            EnergyAndHealthManager.Instance.DecreaseHealth(1);
        }
        if (collision.gameObject.tag == "energy")
        {
            ObstaclePoolManager.Instance.SetPool(obstacle);
            EnergyAndHealthManager.Instance.IncreaseEnergy(1);
        }
    }
   

    public void JumpState()
    {
        StopAllCoroutines();
        _collider.center = _jumpColliderCenter;
        _collider.size = _jumpColliderSize;
        StartCoroutine(Cooldown(_colliderCooldown));
    }
    public void RollState()
    {
        StopAllCoroutines();
        _collider.center = _rollColliderCenter;
        _collider.size = _rollColliderSize;
        StartCoroutine(Cooldown(_colliderCooldown));
    }
    IEnumerator Cooldown(float seconds)
    {
        float counter = seconds;
        while(counter > 0) 
        {
            yield return new WaitForSeconds(0.5f);
            counter=counter-0.5f;
        }
        ResetCollider();
    }
    void ResetCollider()
    {
        _collider.center = _colliderCenterAtStart;
        _collider.size = _colliderSizeAtStart;
    }


}
