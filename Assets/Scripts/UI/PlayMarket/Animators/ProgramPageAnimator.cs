using DG.Tweening;
using UnityEngine;

namespace TankTutorial.Scripts.UI.PlayMarket.Animators
{
    public class ProgramPageAnimator : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _curve;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private float _fadeTime;

        private Vector3 _startPosition;

        private void Start()
        {
            _startPosition = _rectTransform.transform.localPosition;
        }

        public void OpenEventHandler()
        {
            _canvasGroup.alpha = 0;
            _rectTransform.DOAnchorPos(Vector3.zero, _fadeTime).SetEase(_curve);
            _canvasGroup.DOFade(1, _fadeTime);
        }

        public void CloseEventHandler()
        {
            var endPosition = Vector3.right * _rectTransform.rect.width;

            _canvasGroup.alpha = 1;
            _rectTransform.DOAnchorPos(endPosition, _fadeTime).SetEase(Ease.InOutQuint);
            _canvasGroup.DOFade(0, _fadeTime);
        }
    }
}