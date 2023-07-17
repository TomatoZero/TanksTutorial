using System;
using System.Collections.Generic;
using TankTutorial.Scripts.Items;
using TankTutorial.Scripts.ScriptableObject;
using UnityEngine;

namespace TankTutorial.Scripts.UI.InventoryView
{
    public class InventoryViewController : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        [SerializeField] private ItemConfig _inventory;
        [SerializeField] private GameObject _itemPrefab;

        private List<UIItemContainer> _items;


        private void OnEnable()
        {
            
        }

        private void Start()
        {
            CreateListIfNeed();
            foreach (var item in _inventory.Items)
            {
                var instant = CreateInstant();
                _items.Add(instant);
                SetUpInstant(instant, new InventoryItem(){ItemData = item});
            }
        }

        private void CreateListIfNeed()
        {
            if (_items == null) _items = new List<UIItemContainer>();
        }

        private UIItemContainer CreateInstant()
        {
            var instant = Instantiate(_itemPrefab, _content);
            return instant.GetComponent<UIItemContainer>();
        }

        private void SetUpInstant(UIItemContainer instant, InventoryItem item)
        {
            instant.SetItemData(item);
        }
    }
}