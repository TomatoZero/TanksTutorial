using System.Collections.Generic;
using TankTutorial.Scripts.Items;
using UnityEngine;

namespace TankTutorial.Scripts.ScriptableObject
{
    [CreateAssetMenu(fileName = "InventoryItem", menuName = "ScriptableObject/InventoryItemList", order = 1)]
    public class InventoryItemList : UnityEngine.ScriptableObject
    {
        [SerializeField] private List<InventoryItem<ItemData>> _inventoryItems;

        public List<InventoryItem<ItemData>> InventoryItems => _inventoryItems;

        public bool TryAddItem(InventoryItem<ItemData> itemData)
        {
            _inventoryItems.Add(itemData);
            
            return true;
        }
    }
}