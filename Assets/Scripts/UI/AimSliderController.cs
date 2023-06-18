using System;
using UnityEngine;
using UnityEngine.UI;

public class AimSliderController : MonoBehaviour
{
    [SerializeField] private Slider _aimSlider;

    public float AimSlider
    {
        get => _aimSlider.value;
        set => _aimSlider.value = value;
    }

    private void Start()
    {
        AimSlider = 15f;
    }
}