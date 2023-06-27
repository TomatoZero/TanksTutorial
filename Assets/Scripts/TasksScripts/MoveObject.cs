using UnityEngine;

namespace TankTutorial.Scripts.TaskScripts
{
    public class MoveObject : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Vector3 _moveDirection;
        [SerializeField] private float _speed;

        private void FixedUpdate()
        {
            _rigidbody.MovePosition(_rigidbody.position + _moveDirection.normalized * (_speed * Time.fixedDeltaTime));
        }
    }
}