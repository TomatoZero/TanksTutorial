using System;
using TankTutorial.Scripts.Items;
using TankTutorial.Scripts.ScriptableObject;
using UnityEngine;
using UnityEngine.Events;

namespace TankTutorial.Scripts.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private UnityEvent<InventoryItem[]> _bulletInventoryUpdateEvent;
        [SerializeField] private UnityEvent<InventoryItem[]> _tankPartInventoryUpdateEvent;

        private DynamicInventory<BulletItem> _bulletInventory = new DynamicInventory<BulletItem>();
        private DynamicInventory<TankPartItem> _tankPartInventory = new DynamicInventory<TankPartItem>();

        public DynamicInventory<BulletItem> BulletInventory => _bulletInventory;
        public DynamicInventory<TankPartItem> TankPartInventory => _tankPartInventory;

        private void Start()
        {
            _bulletInventory.SetLength(10);
            _tankPartInventory.SetLength(10);
        }

        public void Add(InventoryItem item)
        {
            if (item is BulletItem bulletItem)
            {
                _bulletInventory.Add(bulletItem);
                _bulletInventoryUpdateEvent.Invoke(_bulletInventory.InventoryItems);
            }
            else if (item is TankPartItem tankPartItem)
            {
                _tankPartInventory.Add(tankPartItem);
                _tankPartInventoryUpdateEvent.Invoke(_tankPartInventory.InventoryItems);
            }
            else
            {
                throw new Exception();
            }
        }
        
        public void Add(ItemData item)
        {
            if (item is BulletData bulletItem)
            {
                _bulletInventory.Add(new BulletItem() { ItemData = bulletItem });
                _bulletInventoryUpdateEvent.Invoke(_bulletInventory.InventoryItems);
            }
            else if (item is TankPartData tankPartItem)
            {
                _tankPartInventory.Add(new TankPartItem() { ItemData = tankPartItem });
                _tankPartInventoryUpdateEvent.Invoke(_tankPartInventory.InventoryItems);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}