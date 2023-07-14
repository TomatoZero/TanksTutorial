using UnityEngine;

namespace TankTutorial.Scripts.ScriptableObject
{
    [CreateAssetMenu(fileName = "InventoryItem", menuName = "ScriptableObject/InventoryItem", order = 0)]
    public class ShellItemData : InventoryItemData
    {
        [SerializeField] private int _count;
        
        
    }
}