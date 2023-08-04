using System;
using UnityEngine;

public class SafaArea : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private RectTransform _panelTransform;

    private Rect _currentSafaArea = new Rect();
    private ScreenOrientation _currentOrientation = ScreenOrientation.AutoRotation;
    private bool _isPanelTransformNull;

    private void Start()
    {
        _isPanelTransformNull = _panelTransform == null;
        _currentOrientation = Screen.orientation;
        _currentSafaArea = Screen.safeArea;
        
        ApplySafaArea();
    }

    private void Update()
    {
        if ((_currentSafaArea != Screen.safeArea))
        {
            ApplySafaArea();
        }
    }

    private void ApplySafaArea()
    {
        // if(_isPanelTransformNull) return;

        var safaArea = Screen.safeArea;
        var pixelRect = _canvas.pixelRect;

        _panelTransform.anchorMin = NormalizeSafeAreaPositionFollowingResolution(safaArea.position, pixelRect);
        _panelTransform.anchorMax = NormalizeSafeAreaPositionFollowingResolution(safaArea.position + safaArea.size, pixelRect);

        _currentOrientation = Screen.orientation;
        _currentSafaArea = Screen.safeArea;
    }

    private Vector2 NormalizeSafeAreaPositionFollowingResolution(Vector2 anchor, Rect pixelRect)
    {
        anchor.x /= pixelRect.width;
        anchor.y /= pixelRect.height;

        return anchor;
    }
}