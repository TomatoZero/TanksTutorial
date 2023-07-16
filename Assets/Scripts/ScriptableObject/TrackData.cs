using UnityEngine;

namespace TankTutorial.Scripts.ScriptableObject
{
    [CreateAssetMenu(fileName = "TrackData", menuName = "ScriptableObject/Items/TrackData", order = 1)]
    public class TrackData : TankPartData
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _maxDistanceDriven;
        
        public float Speed => _speed;
        public float MaxDistanceDriven => _maxDistanceDriven;
    }
}