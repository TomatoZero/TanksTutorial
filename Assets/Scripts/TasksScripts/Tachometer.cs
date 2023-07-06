using System;
using TMPro;
using UnityEngine;

namespace TankTutorial.Scripts.TaskScripts
{
    public class Tachometer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _rmp;
        [SerializeField] private Transform _objectTransform;

        private Quaternion _prevRotation;
        private float _revolutions;
        private float _totalRotationAngle = 0f;

        private Vector3 _prevEuger;
        private double _gearRPM;

        private void Update()
        {
            _rmp.text = $"RPM {_gearRPM:F}";
        }

        private void FixedUpdate()
        {
            var currentRotation = _objectTransform.rotation;

            var deltaRotation = Quaternion.Inverse(_prevRotation) * currentRotation;
            var angle = Quaternion.Angle(Quaternion.identity, deltaRotation);

            var angularVelocity = (Math.PI / 180) * angle / Time.fixedDeltaTime;
            _gearRPM = (angularVelocity * 60f) / (Math.PI * 2);

            _prevRotation = currentRotation;
        }
    }
}