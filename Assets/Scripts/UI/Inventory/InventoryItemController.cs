using TankTutorial.Scripts.Items;
using TankTutorial.Scripts.ScriptableObject;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TankTutorial.Scripts.UI.Inventory
{
    public class InventoryItemController : MonoBehaviour
    {
        [SerializeField] private Image _itemIco;
        [SerializeField] private TMP_Text _count;

        private InventoryItem<ItemData> _itemData;
        private int _currentCount;

        public void SetItemData(InventoryItem<ItemData> itemData)
        {
            _itemData = itemData;
            DisableCountIfNeed();
            ReloadData();
        }

        [ContextMenu("Reload Data")]
        public void ReloadData()
        {
            _itemIco.sprite = _itemData.ItemData.ItemIcon;
        }

        private void DisableCountIfNeed()
        {
            
                _count.enabled = false;
        }
    }
}