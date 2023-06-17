using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace TankTutorial.Scripts.Player
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private int _startHp = 100;
        [SerializeField] private HealthEvent _healthReduceEvent;
        [SerializeField] private UnityEvent _deathEvent;

        private int _currentHp;
        private bool _isDead;

        private void Start()
        {
            _currentHp = _startHp;
            _isDead = false;
        }

        public void HealthReduce(int hp)
        {
            if (hp <= 0) throw new Exception("Damage less or equal zero");

            _currentHp -= hp;

            if (_currentHp <= 0 && !_isDead)
                Death();
            
            _healthReduceEvent.Invoke(_currentHp);
        }

        private void Death()
        {
            _isDead = true;
            _deathEvent.Invoke();
        }
    }
}