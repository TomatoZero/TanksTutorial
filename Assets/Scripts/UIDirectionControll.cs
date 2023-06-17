using System;
using UnityEngine;

public class UIDirectionControll : MonoBehaviour
{
    [SerializeField] private bool _useRelativeRotation = true;

    private Quaternion _relativeRotation;

    private void Start()
    {
        _relativeRotation = transform.parent.rotation;
    }

    private void Update()
    {
        if (_useRelativeRotation)
            transform.rotation = _relativeRotation;
    }
}