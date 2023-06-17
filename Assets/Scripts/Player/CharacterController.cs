using UnityEngine;

namespace TankTutorial.Scripts.Player
{
    public class CharacterController : MonoBehaviour
    {
        private ParticleSystem[] _particleSystems;

        private void OnEnable()
        {
            _particleSystems = GetComponentsInChildren<ParticleSystem>();
            for (int i = 0; i < _particleSystems.Length; ++i)
            {
                _particleSystems[i].Play();
            }
        }
        
        private void OnDisable ()
        {
            foreach (var particle in _particleSystems)
            {
                particle.Stop();
            }
        }
    }
}