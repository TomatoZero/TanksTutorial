using UnityEngine;
using UnityEngine.Serialization;

namespace TankTutorial.Scripts.ScriptableObject
{
    [CreateAssetMenu(fileName = "TankPartData", menuName = "ScriptableObject/Items/TankPartData", order = 0)]
    public class TankPartData : ItemData
    {
        [SerializeField] private int _plusHp;
        [SerializeField] private float _maxStrength;
        public int PlusHp => _plusHp;
        public float MaxStrength => _maxStrength;
    }
}