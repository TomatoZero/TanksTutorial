using UnityEngine;
using UnityEngine.UI;

namespace TankTutorial.Scripts.UI
{
    public class HealthBarController : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Image _fillImage;
        [SerializeField] private Color _fullHpColor = Color.green;
        [SerializeField] private Color _halfHpColor = Color.yellow;
        [SerializeField] private Color _zeroHpColor = Color.red;

        private void Start()
        {
            SetupHealthEventHandler(100);
        }

        public void SetupHealthEventHandler(int hp)
        {
            _slider.value = hp;
            if (hp > _slider.maxValue / 2)
                _fillImage.color = Color.Lerp(_halfHpColor, _fullHpColor, hp / _slider.maxValue);
            else _fillImage.color = Color.Lerp(_zeroHpColor, _halfHpColor, hp / _slider.maxValue);
        }

        public void DeathEventHandler()
        {
            gameObject.SetActive(false);
        }
    }
}