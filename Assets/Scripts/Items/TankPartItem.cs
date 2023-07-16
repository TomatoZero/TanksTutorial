using TankTutorial.Scripts.ScriptableObject;

namespace TankTutorial.Scripts.Items
{
    public class TankPartItem<T> : InventoryItem<T>
        where T :TankPartData
    {
        private float _currentStrength;

        public float CurrentStrength
        {
            get => _currentStrength;
            set
            {
                if (value >= 0 && value <= _itemData.MaxStrength)
                    _currentStrength = value;
            }
        }

        public static TankPartItem<TankPartData> GetItem()
        {
            return new TankPartItem<TankPartData>();
        }
        
        public static TankPartItem<TReturn> GetItem<TReturn>() where TReturn : TankPartData
        {
            return new TankPartItem<TReturn>();
        }
    }
}