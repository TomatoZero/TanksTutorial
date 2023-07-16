using TankTutorial.Scripts.ScriptableObject;

namespace TankTutorial.Scripts.Items
{
    public class TurretItem<T> : InventoryItem<T>
        where T : TurretData
    {
        private int _numbShots;

        public int NumbShots
        {
            get => _numbShots;
            set
            {
                if(value >= 0 && value <= _itemData.MaxNumbShots) _numbShots = value;
            }
        }
    }
}