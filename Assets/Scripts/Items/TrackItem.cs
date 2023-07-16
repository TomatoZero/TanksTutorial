using TankTutorial.Scripts.ScriptableObject;

namespace TankTutorial.Scripts.Items
{
    public class TrackItem<T> : InventoryItem<T>
        where T : TrackData
    {
        private float _distanceDriven;

        public float DistanceDriven
        {
            get => _distanceDriven;
            set
            {
                if (value >= 0 && value <= _itemData.MaxDistanceDriven) _distanceDriven = value;
            }
        }
    }
}