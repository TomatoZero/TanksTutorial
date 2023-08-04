using System;
using UnityEditor.DeviceSimulation;
using UnityEngine;

public class SafaArea : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private RectTransform _panelTransform;

    private Rect _currentSafaArea = new Rect();
    private Rect _canvasPixelRect = new Rect();
    private ScreenOrientation _currentOrientation = ScreenOrientation.AutoRotation;
    private bool _isPanelTransformNull;

    private void Start()
    {
        _isPanelTransformNull = _panelTransform == null;
        _currentOrientation = Screen.orientation;
        _currentSafaArea = Screen.safeArea;
        _canvasPixelRect = _canvas.pixelRect;
        
        ApplySafaArea();
    }

    private void FixedUpdate()
    {
        if ((_currentOrientation != Screen.orientation) || (_currentSafaArea != Screen.safeArea) || _canvasPixelRect != _canvas.pixelRect)
        {
            Debug.Log($"Before {_panelTransform.anchorMin} {_panelTransform.anchorMax}");
            ApplySafaArea();
            Debug.Log($"After {_panelTransform.anchorMin} {_panelTransform.anchorMax}");
            Debug.Log("Screen.safeArea" + Screen.safeArea + " " + Screen.safeArea.position);
            Debug.Log($"_canvas.pixelRect {_canvas.pixelRect}");
            
        }
    }

    private void ApplySafaArea()
    {
        if(_isPanelTransformNull) return;

        var safaArea = Screen.safeArea;
        var pixelRect = _canvas.pixelRect;

        _panelTransform.anchorMin = NormalizeSafeAreaPositionFollowingResolution(safaArea.position, pixelRect);
        _panelTransform.anchorMax = NormalizeSafeAreaPositionFollowingResolution(safaArea.position + safaArea.size, pixelRect);

        _currentOrientation = Screen.orientation;
        _currentSafaArea = Screen.safeArea;
        _canvasPixelRect = pixelRect;
    }

    private void ApplySafeAreaOrign()
    {
        if(_isPanelTransformNull) return;

        var safaArea = Screen.safeArea;

        var anchorMin = safaArea.position;
        var anchorMax = safaArea.position + safaArea.size;

        var pixelRect = _canvas.pixelRect;
        anchorMin.x /= pixelRect.width;
        anchorMin.y /= pixelRect.height;

        anchorMax.x /= pixelRect.width;
        anchorMax.y /= pixelRect.height;

        _panelTransform.anchorMin = anchorMin;
        _panelTransform.anchorMax = anchorMax;
        
        _currentOrientation = Screen.orientation;
        _currentSafaArea = Screen.safeArea;
        _canvasPixelRect = pixelRect;
    }

    private Vector2 NormalizeSafeAreaPositionFollowingResolution(Vector2 anchor, Rect pixelRect)
    {
        anchor.x /= pixelRect.width;
        anchor.y /= pixelRect.height;

        return anchor;
    }

}