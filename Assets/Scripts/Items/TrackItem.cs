using TankTutorial.Scripts.ScriptableObject;

namespace TankTutorial.Scripts.Items
{
    public class TrackItem: TankPartItem
    {
        private float _distanceDriven;

        public float DistanceDriven
        {
            get => _distanceDriven;
            set
            {
                if (value >= 0 && value <= ((TrackData)_itemData).MaxDistanceDriven) _distanceDriven = value;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nDistance Driven: {_distanceDriven}";
        }
    }
}