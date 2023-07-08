using System.Collections.Generic;
using UnityEngine;

namespace TankTutorial.Scripts.TaskScripts.Particles
{
    public class WeaponsController : MonoBehaviour
    {
        [SerializeField] private List<Weapon> _weapons;

        private int _currentActive;

        public void ChangeSelectedWeaponEventHandler(int id)
        {
            TurnOff();
            TryChangeIndex(id);
            TurnOn();
        }

        public void PlayBackSpeedChangeEventHandler(float speed)
        {
            _weapons[_currentActive].SetPlayBackSpeed(speed);
        }
        
        public void SetRateOverTimeMultiplierEventHandler(float speed)
        {
            _weapons[_currentActive].SetRateOverTimeMultiplier(speed);
        }

        
        public void TurnOnParticle()
        {
            _weapons[_currentActive].TurnOnParticle();
        }

        public void TurnOffParticle()
        {
            _weapons[_currentActive].TurnOffParticle();
        }

        private void TryChangeIndex(int id)
        {
            if(CheckIndex(id))
                _currentActive = id;
        }
        
        private bool CheckIndex(int id)
        {
            return id >= 0 && id <= _weapons.Count;
        }

        private void TurnOn()
        {
            _weapons[_currentActive].TurnOn();
        }

        private void TurnOff()
        {
            _weapons[_currentActive].TurnOff();
        }
    }
}