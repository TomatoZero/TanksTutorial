using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace TankTutorial.Scripts.UI.PlayMarket.Animators
{
    public class ScrollViewAnimator : MonoBehaviour
    {
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private float duration = 1f;

        public void GoTop()
        {
            scrollRect.DOVerticalNormalizedPos(1f, duration);
        }
    }
}