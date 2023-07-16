using System;
using TankTutorial.Scripts.ScriptableObject;

namespace TankTutorial.Scripts.Items
{
    [Serializable]
    public class InventoryItem
    {
        protected ItemData _itemData;

        public ItemData ItemData
        {
            get => _itemData;
            set => _itemData = value;
        }

        public override string ToString()
        {
            return $"Item Name: {_itemData}\nDescription: {_itemData.Description}";
        }
    }
}