using TMPro;
using UnityEngine;

namespace TankTutorial.Scripts.TaskScripts
{
    public class BouncyBall : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Transform _ground;
        [SerializeField] private TMP_Text _countDetectionOutput;
        [SerializeField] private TMP_Text _distance;

        private int _countDetection;

        private void Update()
        {
            var distance = _transform.position - _ground.position;
            _distance.text = $"Distance: {distance.magnitude}";
        }

        private void OnCollisionEnter(Collision other)
        {
            Debug.Log(other.gameObject.layer);

            _countDetection++;
            _countDetectionOutput.text = $"Count Detection: {_countDetection}";
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.gameObject.layer);
        }
    }
}