using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace TankTutorial.Scripts.TaskScripts
{
    public class RayCastShoot : MonoBehaviour
    {
        [SerializeField] private Transform _fireTransform;
        [SerializeField] private UnityEvent _firedEvent;
        [SerializeField] private float _raycastLength;

        private bool _isFired;

        private void Update()
        {
            if (_isFired)
            {
                var ray = new Ray(_fireTransform.position, _fireTransform.forward);
                if (Physics.Raycast(ray, out var result ,_raycastLength))
                {
                    
                }
            }
        }

        public void ShootEventHandler(InputAction.CallbackContext context)
        {
            // Debug.Log($"11111111");
            if (context.started)
            {
                var ray = new Ray(_fireTransform.position, _fireTransform.forward);
                if (Physics.Raycast(ray, out var result ,_raycastLength))
                {
                    Debug.Log($"Collide with {result.collider.gameObject.name}");
                    Debug.DrawRay(_fireTransform.position, _fireTransform.forward * _raycastLength, Color.blue, 1);
                }
            }
            else if (context.performed)
            {
            }
            else if (context.canceled)
            {
            }
        }
    }
}