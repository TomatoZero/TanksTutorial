using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace TankTutorial.Scripts.Player
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private int _startHp = 100;

        [FormerlySerializedAs("_healthReduceEvent")] [SerializeField]
        private HealthEvent _setCurrentHpEvent;

        [SerializeField] private UnityEvent _deathEvent;

        private int _currentHp;
        private bool _isDead;

        public int CurrentHp => _currentHp;

        private void OnEnable()
        {
            _isDead = false;
            _currentHp = _startHp;

            _setCurrentHpEvent.Invoke(_currentHp);
        }

        private void Start()
        {
            _currentHp = _startHp;
            _isDead = false;

            _setCurrentHpEvent.Invoke(_currentHp);
        }

        public void HealthReduce(int hp)
        {
            if (hp < 0) throw new Exception($"Damage less then zero {hp}");

            _currentHp -= hp;

            if (_currentHp <= 0 && !_isDead)
                Death();

            _setCurrentHpEvent.Invoke(_currentHp);
        }

        public void SetCurrentHp(int hp)
        {
            if (hp <= 0) return;

            _currentHp = hp;
            _setCurrentHpEvent.Invoke(_currentHp);
        }

        private void Death()
        {
            _isDead = true;
            _deathEvent.Invoke();
        }
    }
}