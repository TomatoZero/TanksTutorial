using TankTutorial.Scripts.ScriptableObject;
using UnityEngine;

namespace TankTutorial.Scripts.Items
{
    public class BulletItem<T> : InventoryItem<T>
        where T :BulletData
    {
        private int _countInStack;

        public int CountInStack
        {
            get => _countInStack;
            set
            {
                if(value >= 0 && value <= _itemData.MaxCountInStack) _countInStack = value;
            }
        }
    }
}