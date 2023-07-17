using System;
using TankTutorial.Scripts.Inventory;
using TankTutorial.Scripts.Items;
using UnityEngine.Events;

namespace TankTutorial.Scripts
{
    [Serializable]
    public class HealthEvent : UnityEvent<int>
    {
    }
    
    [Serializable]
    public class UpdateInventory : UnityEvent<DynamicInventory<InventoryItem>>
    {
    }
}