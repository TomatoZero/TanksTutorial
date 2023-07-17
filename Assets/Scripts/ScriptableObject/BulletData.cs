using UnityEngine;

namespace TankTutorial.Scripts.ScriptableObject
{
    [CreateAssetMenu(fileName = "BulletData", menuName = "ScriptableObject/Items/BulletData", order = 0)]
    public class BulletData : ItemData
    {
        [SerializeField] private int _maxCountInStack;
        [SerializeField] private float _plusTimeBeforeExplosion;

        public int MaxCountInStack => _maxCountInStack;
        public float PlusTimeBeforeExplosion => _plusTimeBeforeExplosion;
    }
}