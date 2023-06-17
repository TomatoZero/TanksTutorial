using UnityEngine;

namespace TankTutorial.Scripts.Player
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private int _startHealth = 100;
        [SerializeField] private HealthEvent _healthReduceEvent;
    }
}