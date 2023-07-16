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

        private void Start()
        {
            _item = new TrackItem();
            _item.ItemData = _track;
            ((TrackItem)_item).DistanceDriven = 2;
            ((TrackItem)_item).CurrentStrength = 3;

            _button.onClick.AddListener(() => { Debug.Log( _item.ToString());});
        }

        
        [ContextMenu("Reload Data")]
        public void ReloadData()
        {
            _itemIco.sprite = _item.ItemData.ItemIcon;
        }
    }
}