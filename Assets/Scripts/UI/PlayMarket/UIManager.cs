using DG.Tweening;
using UnityEngine;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _curve;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private float _fadeTime;

        private Vector3 _startPosition;

        private void Start()
        {
            var transform1 = _rectTransform.transform;
            Debug.Log($"position {transform1.position} local {transform1.localPosition}");
            
            _startPosition = _rectTransform.transform.localPosition;
            _startPosition.y *= 2;
        }

        public void PanelFadeIn()
        {
            _canvasGroup.alpha = 0;
            _rectTransform.DOAnchorPos(_startPosition, _fadeTime).SetEase(_curve);
            _canvasGroup.DOFade(1, _fadeTime);
        }

        public void PanelFadeOut()
        {
            _canvasGroup.alpha = 1;
            _rectTransform.DOAnchorPos(Vector3.zero, _fadeTime).SetEase(Ease.InOutQuint);
            _canvasGroup.DOFade(0, _fadeTime);
        }
    }
}