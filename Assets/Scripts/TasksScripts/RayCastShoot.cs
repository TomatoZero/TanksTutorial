using UnityEngine;
using UnityEngine.InputSystem;

namespace TankTutorial.Scripts.TaskScripts
{
    public class RayCastShoot : MonoBehaviour
    {
        [SerializeField] private Transform _fireTransform;
        [SerializeField] private float _raycastLength;

        private bool _isFired;

        public void ShootEventHandler(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                var ray = new Ray(_fireTransform.position, _fireTransform.forward);
                if (Physics.Raycast(ray, out var result, _raycastLength))
                {
                    Debug.Log($"Collide with {result.collider.gameObject.name}");
                    Debug.DrawRay(_fireTransform.position, _fireTransform.forward * _raycastLength, Color.blue, 1);


                    (result.transform.gameObject.GetComponent<MeshRenderer>()).material.color = Color.red;
                    var renderers = result.transform.gameObject.GetComponentsInChildren<MeshRenderer>();
                    foreach (var mesh in renderers) mesh.material.color = Color.red;
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