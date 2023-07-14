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

        private void Start()
        {
            CreateListIfNeed();
            foreach (var item in _inventory.InventoryItems)
            {
                var instant = CreateInstant();
                _items.Add(instant);
                SetUpInstant(instant, item);
            }
        }

        public void AddIfPossible(InventoryItem item)
        {
            if (CheckPossibilityToAdd(item))
            {
                CreateListIfNeed();
                var instant = CreateInstant();
                _items.Add(instant);
                SetUpInstant(instant, item);
            }
        }

        private bool CheckPossibilityToAdd(InventoryItem item)
        {
            return _inventory.TryAddItem(item);
        }

        private void CreateListIfNeed()
        {
            if (_items == null) _items = new List<InventoryItemController>();
        }

        private InventoryItemController CreateInstant()
        {
            var instant = Instantiate(_itemPrefab, _content);
            return instant.GetComponent<InventoryItemController>();
        }

        private void SetUpInstant(InventoryItemController instant, InventoryItem item)
        {
            instant.SetItemData(item);
        }
    }
}