using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Lines
{

    private void Start()
    {
        SetLine(1);
    }

    void Update()
    {
        HandleInputs();
    }

    private void HandleInputs()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            LineIncrease();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LineDecrease();
        }
    }
}
