using System;
using TankTutorial.Scripts.Items;
using UnityEngine;

namespace TankTutorial.Scripts.Inventory
{
    public class Inventory : MonoBehaviour
    {
        private DynamicInventory<BulletItem> _bulletInventory;
        private DynamicInventory<TankPartItem> _tankPartInventory;

        public DynamicInventory<BulletItem> BulletInventory => _bulletInventory;
        public DynamicInventory<TankPartItem> TankPartInventory => _tankPartInventory;

        private void Start()
        {
        }

        public void Add(InventoryItem item)
        {
            if (item is BulletItem bulletItem) _bulletInventory.Add(bulletItem);
            else if (item is TankPartItem tankPartItem) _tankPartInventory.Add(tankPartItem);
            else
            {
                throw new Exception();
            }
        }
    }
}