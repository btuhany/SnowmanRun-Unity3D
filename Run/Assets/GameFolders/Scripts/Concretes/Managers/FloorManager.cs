using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField] [Range(0.25f,12f)] float moveSpeed;
    
    Material _material;


    private void Awake()
    {
        _material = GetComponentInChildren<MeshRenderer>().material;
    }
    private void Update()
    {
        _material.mainTextureOffset += Vector2.down*Time.deltaTime*moveSpeed;
    }
}
