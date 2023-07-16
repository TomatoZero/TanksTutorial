using System;
using TankTutorial.Scripts.ScriptableObject;
using UnityEngine;

namespace TankTutorial.Scripts.Items
{
    [Serializable]
    public class InventoryItem<T>
        where T : ItemData
    {
        [SerializeField] protected T _itemData;

        public T ItemData
        {
            get => _itemData;
            set => _itemData = value;
        }
    }

    public interface IItem<T> where T : ItemData
    {
        public T ItemData { get; set; }
    }

    public abstract class Item
    {
        public abstract T GetItem<T>() where T: InventoryItem<ItemData>;
    }
}