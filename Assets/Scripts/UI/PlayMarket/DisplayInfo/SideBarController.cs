using System.Collections;
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
            gameObject.SetActive(true);
            _openEvent.Invoke();
        }

        public void Close()
        {
            _closeEvent.Invoke();
        }

        private IEnumerator DeactivateObject()
        {
            yield return new WaitForSeconds(1);
            gameObject.SetActive(false);
        }
    }
}