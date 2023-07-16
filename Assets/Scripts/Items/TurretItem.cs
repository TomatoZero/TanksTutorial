using TankTutorial.Scripts.ScriptableObject;

namespace TankTutorial.Scripts.Items
{
    public class TurretItem: InventoryItem
    {
        private int _numbShots;

        public int NumbShots
        {
            get => _numbShots;
            set
            {
                if(value >= 0 && value <= ((TurretData)_itemData).MaxNumbShots) _numbShots = value;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nShots left: {((TurretData)_itemData).MaxNumbShots - _numbShots}";
        }
    }
}