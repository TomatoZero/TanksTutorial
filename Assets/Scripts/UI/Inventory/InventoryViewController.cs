using System.Collections.Generic;
using TankTutorial.Scripts.ScriptableObject;
using UnityEngine;

namespace TankTutorial.Scripts.UI.Inventory
{
    public class InventoryViewController : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        [SerializeField] private InventoryItemList _inventory;
        [SerializeField] private GameObject _itemPrefab;
        
        private List<InventoryItemController> _items;
        
        public void AddIfPossible(InventoryItem item)
        {
            if (CheckPossibilityToAdd(item))
            {
                CreateListIfNeed();
                _items.Add(CreateInstant());
            }
        }

        private bool CheckPossibilityToAdd(InventoryItem item)
        {
            return _inventory.TryAddItem(item);
        }
        
        private void CreateListIfNeed()
        {
            if (_items.Equals(null)) _items = new List<InventoryItemController>();
        }

        private InventoryItemController CreateInstant()
        {
            var instant = Instantiate(_itemPrefab, _content);
            return instant.GetComponent<InventoryItemController>();
        }
    }
}