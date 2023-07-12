using UnityEngine;

namespace TankTutorial.Scripts.ScriptableObject
{
    [CreateAssetMenu(fileName = "InventoryItem", menuName = "ScriptableObject/InventoryItem", order = 0)]
    public class ShellItem : InventoryItem
    {
        [SerializeField] private int _count;
        
        
    }
}