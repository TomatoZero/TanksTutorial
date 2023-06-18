using TankTutorial.Scripts.Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace TankTutorial.Scripts
{
    public class ShellExplosion : MonoBehaviour
    {
        [SerializeField] private LayerMask _pLayerMask;
        [SerializeField] private ParticleSystem _exposionParticle;
        [SerializeField] private AudioSource _explosionSource;
        [SerializeField] private float _maxDamage = 100f;
        [SerializeField] private float _explosionForce = 1000f;
        [SerializeField] private float _maxLifeTime = 2f;
        [SerializeField] private float _explosionRadius = 5f;

        private void Start()
        {
            Destroy(gameObject, _maxLifeTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            var hitColliders = new Collider[10];
            var size = Physics.OverlapSphereNonAlloc(transform.position, _explosionRadius, hitColliders, _pLayerMask); //Like Physics.OverlapSphere, but generates no garbage; from docs

            foreach (var hitCollider in hitColliders)
            {
                if(hitCollider == null) break;
                if (hitCollider.TryGetComponent(out Rigidbody rb))
                {
                    rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);

                    if (rb.TryGetComponent(out HealthController playerHealth))
                    {
                        playerHealth.HealthReduce((int)CalculateDamage(rb.position));
                    }
                }
            }

            _exposionParticle.transform.parent = null;
            _exposionParticle.Play();
            _explosionSource.Play();
            
            Destroy(_exposionParticle.gameObject, _exposionParticle.duration);
            
        }

        private float CalculateDamage(Vector3 targetPosition)
        {
            var explosionDistance = (targetPosition - transform.position).magnitude;
            var relativeDistance = (_explosionRadius - explosionDistance) / _explosionRadius;
            var damage = relativeDistance * _maxDamage;
            return Mathf.Max(0, damage);
        }
    }
}