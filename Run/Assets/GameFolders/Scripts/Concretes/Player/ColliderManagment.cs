using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManagment : MonoBehaviour
{
    [SerializeField] float _colliderCooldown;
    PlayerController _player;
    BoxCollider _bottomCollider;
    CapsuleCollider _upperCollider;

    private void Awake()
    {
        _bottomCollider = GetComponent<BoxCollider>();
        _upperCollider = GetComponent<CapsuleCollider>();
    }

    public void JumpState()
    {
        _upperCollider.enabled = true;
        _bottomCollider.enabled= false;
       StartCoroutine(ColliderCooldown(_colliderCooldown, _bottomCollider));
    }
    public void RollState()
    {
        _bottomCollider.enabled= true;
        _upperCollider.enabled= false;
        StartCoroutine(ColliderCooldown(_colliderCooldown, _upperCollider));
    }
    IEnumerator ColliderCooldown(float seconds,Collider collider)
    {
        float counter = seconds;
        while(counter > 0) 
        {
            yield return new WaitForSeconds(0.5f);
            counter=counter-0.5f;
        }
        collider.enabled= true;
    }
}
