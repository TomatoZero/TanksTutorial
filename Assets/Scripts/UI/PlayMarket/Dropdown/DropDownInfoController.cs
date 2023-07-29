using UnityEngine;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class DropDownInfoController : MonoBehaviour
    {
        private bool _isActive = false;

        public void Press()
        {
            if (_isActive)
            {
                _isActive = false;
                gameObject.SetActive(false);
            }
            else
            {
                _isActive = true;
                gameObject.SetActive(true);
            }
        }
    }
}