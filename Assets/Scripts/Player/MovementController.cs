using UnityEngine;
using UnityEngine.InputSystem;

namespace TankTutorial.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private int _plyerNum;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _turnSpeed;

        public void MoveEventHandler(InputAction.CallbackContext context)
        {

        }
    }
}