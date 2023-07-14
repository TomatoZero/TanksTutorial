using TankTutorial.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace TankTutorial.Scripts.UI.Inventory
{
    public class InventoryItemController : MonoBehaviour
    {
        [SerializeField] private Image _itemIco;
        [SerializeField] private TMP_Text _count;

        private InventoryItem _itemData;
        private int _currentCount;

        public void SetItemData(InventoryItem itemData)
        {
            _itemData = itemData;
            DisableCountIfNeed();
            itemData.CheckData();
            _currentCount = itemData.CurrentCount;
            ReloadData();
        }

        [ContextMenu("Reload Data")]
        public void ReloadData()
        {
            _itemIco.sprite = _itemData.ItemData.ItemIcon;
        }

        private void DisableCountIfNeed()
        {
            if (!_itemData.ItemData.IsStackable)
                _count.enabled = false;
        }
    }
}