using System.Collections;
using TankTutorial.Managers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace TankTutorial.Scripts.Player
{
    public class ShootController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _shell;
        [SerializeField] private float _minLaunchForce = 15f;
        [SerializeField] private float _maxLaunchForce = 30f;
        [SerializeField] private float _maxChargeTime = 0.75f;
        [SerializeField] private Transform _fireTransform;
        [SerializeField] private UnityEvent _firedEvent;
        [SerializeField] private AimSliderController _aimSlider;

        private bool _isFired;
        private float _currentLaunchForce;
        private float _chargeSpeed;

        private void Start()
        {
            _isFired = true;
            _chargeSpeed = (_maxLaunchForce - _minLaunchForce) / _maxChargeTime;
        }

        private void Update()
        {
            if (!_isFired)
            {
                _currentLaunchForce += _chargeSpeed * Time.deltaTime;
                _aimSlider.AimSlider = _currentLaunchForce;

                // Debug.Log($"deltatime {Time.deltaTime} {_chargeSpeed} * {Time.deltaTime * _chargeSpeed}");
            }
        }

        public void ShootEventHandler(InputAction.CallbackContext context)
        {
            // Debug.Log($"context {context}");
            
            if (context.started)
            {
                _isFired = false;
                _currentLaunchForce = _minLaunchForce;
                StartCoroutine(ShootHoldTimer());
            }
            else if (context.performed)
            {
            }
            else if (context.canceled)
            {
                StopCoroutine(ShootHoldTimer());
                Shoot();
            }
        }

        private IEnumerator ShootHoldTimer()
        {
            if (!_isFired)
            {
                yield return new WaitForSeconds(_maxChargeTime);
                if (!_isFired)
                {
                    _currentLaunchForce = _maxLaunchForce;
                    Shoot();
                }
            }
        }

        private void Shoot()
        {
            if (_isFired) return;

            _isFired = true;
            _firedEvent.Invoke();

            var shellInstant = Instantiate(_shell, _fireTransform.position, _fireTransform.rotation);

            shellInstant.velocity = _currentLaunchForce * _fireTransform.forward;
            _aimSlider.AimSlider = _minLaunchForce;
        }
    }
}