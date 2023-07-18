using TankTutorial.Scripts.Items;
using TankTutorial.Scripts.ScriptableObject;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TankTutorial.Scripts.UI.InventoryView
{
    [RequireComponent(typeof(Button))]
    public class UIItemContainer : MonoBehaviour
    {
        [SerializeField] private Image _itemIco;
        [SerializeField] private Button _button;
        
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
            ReloadData();
        }
    }
}