using UnityEngine;

namespace TankTutorial.Scripts.Player
{
    public class EffectsController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] _dustParticles;
        [SerializeField] private GameObject _explosionParticlePrefab;

        private ParticleSystem _explosionParticle;
        private AudioSource _explosionAudio;

        private void Start()
        {
            _explosionParticle = Instantiate(_explosionParticlePrefab).GetComponent<ParticleSystem>();
            _explosionAudio = _explosionParticle.GetComponent<AudioSource>();
            _explosionParticle.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            foreach (var particle in _dustParticles) particle.Play();
        }

        private void OnDisable()
        {
            foreach (var particle in _dustParticles) particle.Stop();
        }

        public void DeathEventHandler()
        {
            _explosionParticle.transform.position = transform.position;
            _explosionParticle.gameObject.SetActive(true);

            _explosionParticle.Play();

            _explosionAudio.Play();
        }
    }
}