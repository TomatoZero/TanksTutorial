using UnityEngine;
using UnityEngine.UI;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class ContentSizeController : MonoBehaviour
    {
        [SerializeField] private ContentSizeFitter _contentSize;

        public void OnTransformChildrenChanged()
        {
            _contentSize.SetLayoutHorizontal();
            _contentSize.SetLayoutVertical();
        }
    }
}