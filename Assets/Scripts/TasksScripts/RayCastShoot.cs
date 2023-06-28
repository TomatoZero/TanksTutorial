using UnityEngine;
using UnityEngine.InputSystem;

namespace TankTutorial.Scripts.TaskScripts
{
    public class RayCastShoot : MonoBehaviour
    {
        [SerializeField] private Transform _fireTransform;
        [SerializeField] private float _raycastLength;
        [SerializeField] private bool _useSphereCast = false;
        [SerializeField, Range(0.1f, 20)] private float _radius;

        private bool _isFired;

        public void ShootEventHandler(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                ShootStart();   
            }
            else if (context.performed)
            {
            }
            else if (context.canceled)
            {
            }
        }

        private void ShootStart()
        {
            var ray = new Ray(_fireTransform.position, _fireTransform.forward);
            if (!_useSphereCast)
            {
                if (Physics.Raycast(ray, out var hitInfo, _raycastLength)) RayCastOutput(hitInfo);
            }
            else
            {
                if(Physics.SphereCast(ray, _radius, out var hitInfo, _raycastLength)) RayCastOutput(hitInfo);
            }
        }
        
        private void RayCastOutput(RaycastHit hit)
        {
            Debug.Log($"Collide with {hit.collider.gameObject.name}");
            Debug.DrawRay(_fireTransform.position, _fireTransform.forward * _raycastLength, Color.blue, 1);
            
            var renderers = hit.transform.gameObject.GetComponentsInChildren<MeshRenderer>();
            foreach (var mesh in renderers) mesh.material.color = Color.red;
        }
    }
}