using UnityEngine;
using UnityEngine.UI;

namespace TankTutorial.Scripts.UI
{
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
}