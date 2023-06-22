using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TankTutorial.Scripts.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CinemachineTargetGroup _targetGroup;
        [SerializeField] private PlayerInputManager _playerInputManager;

        public void PlayerJoinEventHandler(PlayerInput playerInput)
        {
            _targetGroup.AddMember(playerInput.gameObject.transform, 1, 10);
        }
    }
}