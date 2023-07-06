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
        private Vector3 _rotationAngles;

        private void Start()
        {
            var renderers = gameObject.GetComponentsInChildren<MeshRenderer>();
            foreach (var mesh in renderers) mesh.material.color = _color;
        }

        private void FixedUpdate()
        {
            _rotation.Normalize();
            var rotationAmount = _rotationSpeed * 6f * Time.fixedDeltaTime;
            
            if (_isQuaternion)
            {
                // var target = Quaternion.AngleAxis(rotationAmount, _rotation);
                // or
                // var target = Quaternion.Euler(_rotation * rotationAmount);
                
                // transform.rotation *= target;

                _transform.Rotate(_rotation, rotationAmount);
                
                //Not permanent
                // var startRotation = transform.rotation;
                // var targetRotation = Quaternion.LookRotation(_rotation, Vector3.up);
                // Quaternion newRotation = Quaternion.RotateTowards(startRotation, targetRotation, rotationAmount);
                // transform.rotation = newRotation;
            }
            else
            {
                _currentEulerAngeles += _rotation * rotationAmount;
                _transform.eulerAngles = _currentEulerAngeles;
                
                // _rotationAngles += _rotation * rotationAmount;
                // Quaternion rotationQuaternion = Quaternion.Euler(_rotationAngles);
                // transform.rotation = rotationQuaternion;
            }
        }
    }
}