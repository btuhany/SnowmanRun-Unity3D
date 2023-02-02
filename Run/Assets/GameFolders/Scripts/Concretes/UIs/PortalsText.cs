using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PortalsText : MonoBehaviour
{
    TextMeshProUGUI _textMesh;
    private void Awake()
    {
        _textMesh = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        _textMesh.SetText(GameManager.Instance.PortalNumber.ToString() + " PORTALS LEFT");
    }
}
