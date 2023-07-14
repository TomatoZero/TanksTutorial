using UnityEngine;

namespace TankTutorial.Scripts.ScriptableObject
{
    [CreateAssetMenu(fileName = "TankPartData", menuName = "ScriptableObject/TankPartData", order = 0)]
    public class TankPartData : InventoryItemData
    {
        [SerializeField] private int _maxStrength = 10;

        public int MaxStrength => _maxStrength;
    }
}