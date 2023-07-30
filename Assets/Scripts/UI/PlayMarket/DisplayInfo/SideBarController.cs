using UnityEngine;
using UnityEngine.Events;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class SideBarController : MonoBehaviour
    {
        [SerializeField] private UnityEvent _openEvent;
        [SerializeField] private UnityEvent _closeEvent;

        public void Open()
        {
            _openEvent.Invoke();
        }

        public void Close()
        {
            _closeEvent.Invoke();
        }
    }
}