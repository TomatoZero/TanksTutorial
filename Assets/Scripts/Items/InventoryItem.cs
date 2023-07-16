using System;
using TankTutorial.Scripts.ScriptableObject;
using UnityEngine;

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

    public interface IItem<T> where T : ItemData
    {
        public T ItemData { get; set; }
    }

    public abstract class Item<T>
    {
        protected T _itemData;

        public T ItemData
        {
            get => _itemData;
            set => _itemData = value;
        }
    }

    public abstract class TankPartItem2<T> : Item<TankPartData>
        where T : TankPartData
    {
        
    }
    
    public abstract class TurretItem2<T>: Item<TankPartData>
        where T : TurretData
    {
        
    }
}