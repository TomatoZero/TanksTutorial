using TankTutorial.Scripts.Items;
using TankTutorial.Scripts.ScriptableObject;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TankTutorial.Scripts.UI.Inventory
{
    [RequireComponent(typeof(Button))]
    public class UIItemContainer : MonoBehaviour
    {
        [SerializeField] private Image _itemIco;
        [SerializeField] private TMP_Text _briefInfo;
        [SerializeField] private Button _button;

        [SerializeField] private TrackData _track;
        
        private InventoryItem _item;
        
        public InventoryItem Item
        {
            get => _item;
            set => _item = value;
        }
        
        [ContextMenu("Reload Data")]
        public void ReloadData()
        {
            _itemIco.sprite = _item.ItemData.ItemIcon;
        }
        
        public void SetItemData(InventoryItem itemData)
        {
            _item = itemData;
            DisableCountIfNeed();
            ReloadData();
        }

        private void DisableCountIfNeed()
        {
            // _briefInfo.enabled = false;
        }
    }
}