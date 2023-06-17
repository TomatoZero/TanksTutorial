using UnityEngine;
using UnityEngine.InputSystem;

namespace TankTutorial.Player
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource _movementAudio;
        [SerializeField] private AudioClip _engineIdle;
        [SerializeField] private AudioClip _engineDriving;
        [SerializeField] private float _pitchRange;

        private float _originalPitch;
        private Vector2 _moveDirection;

        private void Start()
        {
            _originalPitch = _movementAudio.pitch;
        }

        public void MoveEventHandler(InputAction.CallbackContext context)
        {
            _moveDirection = context.ReadValue<Vector2>();
            var _horizontal = _moveDirection.x;
            var _vertical = _moveDirection.y;
            
            if (Mathf.Abs (_vertical) < 0.1f && Mathf.Abs (_horizontal) < 0.1f)
            {
                if (_movementAudio.clip == _engineDriving)
                {
                    _movementAudio.clip = _engineIdle;
                    _movementAudio.pitch = Random.Range (_originalPitch - _pitchRange, _originalPitch + _pitchRange);
                    _movementAudio.Play ();
                }
            }
            else
            {
                if (_movementAudio.clip == _engineDriving)
                {
                    _movementAudio.clip = _engineDriving;
                    _movementAudio.pitch = Random.Range(_originalPitch - _pitchRange, _originalPitch + _pitchRange);
                    _movementAudio.Play();
                }
            }
        }
    }
}