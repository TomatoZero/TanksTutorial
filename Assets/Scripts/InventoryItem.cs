using System;
using TankTutorial.Scripts.ScriptableObject;
using UnityEngine;

namespace TankTutorial.Scripts
{
    [Serializable]
    public class InventoryItem
    {
        [SerializeField] private InventoryItemData _itemData;
        public InventoryItemData ItemData => _itemData;
        public int CurrentCount => _currentCount;

        private int _currentCount = -1;

        public void CheckData()
        {
            if (_currentCount == -1) _currentCount = _itemData.StackMaxCount;
        }
    }
}