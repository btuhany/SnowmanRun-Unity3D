using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoTextUpdate : MonoBehaviour
{
    TextMeshProUGUI _textMesh;
   
    private void Awake()
    {
        _textMesh = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _textMesh.SetText("COMPLETED IN " + Time.time.ToString("0") + " SECONDS, PLAY AGAIN?");
    }
}
