using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Lines : MonoBehaviour
{
    const float _lineDistance = 4.5f;
    private Vector3 line;

    private Vector3[] lines = 
    {
        Vector3.left*_lineDistance,
        Vector3.zero,
        Vector3.right*_lineDistance,
    };

    protected bool IsInLine { get => transform.position.x == GetLine().x; }

    protected void LineIncrease()
    {
        
        if (GetLineNumber() == 2)
            return;
        else
            line = lines[GetLineNumber() + 1];
       
    }
    protected void LineDecrease()
    {
       
        if (GetLineNumber() == 0)
            return;
        else
            line = lines[GetLineNumber() - 1];
    
    }

    public int GetLineNumber()
    {
        if (line == lines[0])
        {
            return 0;
        }
        else if (line == lines[1])
        {
            return 1;
        }
        else 
        {
            return 2;
        }
    }
    public Vector3 GetLine()
    {
        if (line == lines[0])
        {
            return lines[0];
        }
        else if (line == lines[1])
        {
            return lines[1];
        }
        else
        {
            return lines[2];
        }
    }
  
    protected void SetLine(int newLine)
    {
        if (newLine > 2 || newLine < 0)
            return;
        line = lines[newLine];
    }

}
