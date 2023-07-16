using TankTutorial.Scripts.ScriptableObject;

namespace TankTutorial.Scripts.Items
{
    public class TankPartItem : InventoryItem
    {
        private float _currentStrength;

        public float CurrentStrength
        {
            get => _currentStrength;
            set
            {
                if (value >= 0 && value <= ((TankPartData)_itemData).MaxStrength)
                    _currentStrength = value;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nStrength: {_currentStrength}";
        }
    }
}