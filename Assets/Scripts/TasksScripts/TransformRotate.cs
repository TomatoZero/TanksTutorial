using System;
using UnityEngine;

public class TransformRotate : MonoBehaviour
{
    [SerializeField] private Color _color;
    [SerializeField] private bool _isQuaternion; 
    
    private void Start()
    {
        var renderers = gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach (var mesh in renderers) mesh.material.color = _color;
    }
    
    
    
}