using UnityEngine;

namespace TankTutorial.Scripts.TaskScripts
{
    public class TransformRotate : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [Space] [SerializeField] private float _rotationSpeed = 45;
        [SerializeField] private Vector3 _rotation;
        [Space] [SerializeField] private Color _color;
        [SerializeField] private bool _isQuaternion;

        private Vector3 _currentEulerAngeles;

        private void Start()
        {
            var renderers = gameObject.GetComponentsInChildren<MeshRenderer>();
            foreach (var mesh in renderers) mesh.material.color = _color;
        }

        private void FixedUpdate()
        {
            _rotation.Normalize();

            if (_isQuaternion)
            {
                var target = Quaternion.Euler(_rotation * (_rotationSpeed * Time.fixedDeltaTime));
                transform.rotation *= target;
                // _transform.Rotate(_rotation, Space.World);
            }
            else
            {
                _currentEulerAngeles += _rotation * (Time.fixedDeltaTime * _rotationSpeed);
                _transform.eulerAngles = _currentEulerAngeles;
            }
        }
    }
}