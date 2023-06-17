using System;
using UnityEngine;

namespace TankTutorial.Player
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource _movementAudio;
        [SerializeField] private AudioClip _engineIdle;
        [SerializeField] private AudioClip _engineDriving;
        
        private float _originalPitch;

        private void Start()
        {
            _originalPitch = _movementAudio.pitch;
        }
    }
}