using TankTutorial.Scripts.ScriptableObject;
using UnityEngine;

namespace TankTutorial.Scripts.Items
{
    public class BulletItem: InventoryItem
    {
        private int _countInStack;

        public int CountInStack
        {
            get => _countInStack;
            set
            {
                if(value >= 0 && value <= ((BulletData)_itemData).MaxCountInStack) _countInStack = value;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nIn Stack: {_countInStack}";
        }
    }
}