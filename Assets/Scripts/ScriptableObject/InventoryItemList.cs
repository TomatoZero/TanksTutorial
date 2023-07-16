using System.Collections.Generic;
using TankTutorial.Scripts.Items;
using UnityEngine;

namespace TankTutorial.Scripts.ScriptableObject
{
    [CreateAssetMenu(fileName = "InventoryItem", menuName = "ScriptableObject/InventoryItemList", order = 1)]
    public class InventoryItemList : UnityEngine.ScriptableObject
    {
        [SerializeField] private List<InventoryItem> _inventoryItems;

        public List<InventoryItem> InventoryItems => _inventoryItems;

        public bool TryAddItem(InventoryItem itemData)
        {
            _inventoryItems.Add(itemData);
            
            return true;
        }
    }
}