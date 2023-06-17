using UnityEngine;
using UnityEngine.InputSystem;

namespace TankTutorial.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private int _plyerNum;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _turnSpeed;

        private Vector2 _moveDirection;

        public void MoveEventHandler(InputAction.CallbackContext context)
        {
            _moveDirection = context.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            //move
            _rigidbody.MovePosition(_rigidbody.position +
                                    transform.forward * (_moveDirection.y * _moveSpeed * Time.deltaTime));

            //rotate
            var turn = _moveDirection.x * _turnSpeed * Time.deltaTime;
            var turnRotation = Quaternion.Euler(0f, turn, 0f);
            _rigidbody.MoveRotation(_rigidbody.rotation * turnRotation);
        }
    }
}