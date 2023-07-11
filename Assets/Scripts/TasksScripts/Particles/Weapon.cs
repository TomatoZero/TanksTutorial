using System.Collections.Generic;
using UnityEngine;

namespace TankTutorial.Scripts.TaskScripts.Particles
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private List<ParticleSystem> _child;

        private float _rateOverTime;
        private List<float> _rateOverTimeChild;

        private ParticleSystem.MainModule _main;
        private List<ParticleSystem.MainModule> _mainChild;

        private void OnEnable()
        {
            _main = _particle.main;

            _mainChild = new List<ParticleSystem.MainModule>();
            foreach (var system in _child) _mainChild.Add(system.main);

            var emission = _particle.emission;
            _rateOverTime = emission.rateOverTimeMultiplier;
            _rateOverTimeChild = new List<float>();

            foreach (var system in _child)
            {
                _rateOverTimeChild.Add(system.emission.rateOverTimeMultiplier);
            }
        }

        public void TurnOn()
        {
            gameObject.SetActive(true);
        }

        public void TurnOff()
        {
            gameObject.SetActive(false);
        }

        public void TurnOnParticle()
        {
            _particle.Play();
        }

        public void TurnOffParticle()
        {
            _particle.Stop();
            _particle.Clear();
        }

        public void SetRateOverTimeMultiplier(float n)
        {
            var emission = _particle.emission;
            emission.rateOverTimeMultiplier = _rateOverTime * n;

            for (int i = 0; i < _child.Count; i++)
            {
                var emissionChild = _child[i].emission;
                emissionChild.rateOverTimeMultiplier = _rateOverTimeChild[i] * n;
            }
        }

        public void SetPlayBackSpeed(float speed)
        {
            _main.simulationSpeed = speed;

            foreach (var mainModule in _mainChild)
            {
                var module = mainModule;
                module.simulationSpeed = speed;
            }
        }
    }
}