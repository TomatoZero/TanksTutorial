namespace TankTutorial.Scripts.Inventory
{
    public class DynamicInventory<T>
    {
        private T[] _inventoryItems;

        private int _itemsLength;
        
        public T[] InventoryItems
        {
            get => _inventoryItems;
            set
            {
                if(value != null)
                    _inventoryItems = value;
            }
        }

        public void SetLength(int lenght)
        {
            _itemsLength = lenght;
            
            if (_inventoryItems is null)
                _inventoryItems = new T[lenght];
            
        }
        
        public void Add(T item)
        {
            CreateInventoryIfNeed();
            AddIfCan(item);
        }

        private bool AddIfCan(T item)
        {
            var emptySlotId = FindEmptySlot();

            if (emptySlotId == -1)
                return false;
            else
            {
                _inventoryItems[emptySlotId] = item;
                return true;
            }
        }

        private int FindEmptySlot()
        {
            for (var i = 0; i < _inventoryItems.Length; i++)
            {
                if (_inventoryItems[i] == null)
                    return i;
            }
            
            return -1;
        }
        
        private void CreateInventoryIfNeed()
        {
            if (_inventoryItems == null)
                _inventoryItems = new T[_itemsLength];
        }

        private bool IsFreeSpace()
        {
            return true;
        }
    }
}