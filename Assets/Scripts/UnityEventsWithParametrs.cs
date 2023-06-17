using System;
using UnityEngine.Events;

namespace TankTutorial.Scripts
{
    [Serializable]
    public class HealthEvent : UnityEvent<int>
    {
    }
}