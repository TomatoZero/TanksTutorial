using UnityEngine;

namespace TankTutorial.Scripts.ScriptableObject
{
    [CreateAssetMenu(fileName = "TurretData", menuName = "ScriptableObject/Items/TurretData", order = 0)]
    public class TurretData : TankPartData
    {
        [SerializeField] private float _plusShootSpeed;
        [SerializeField] private int _maxNumbShots;

        public float PlusShootSpeed => _plusShootSpeed;

        public int MaxNumbShots => _maxNumbShots;
    }
}