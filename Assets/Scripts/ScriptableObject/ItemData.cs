using UnityEngine;

namespace TankTutorial.Scripts.ScriptableObject
{
    [CreateAssetMenu(fileName = "InventoryItem", menuName = "ScriptableObject/Items/ItemData", order = 0)]
    public class ItemData : UnityEngine.ScriptableObject
    {
        [SerializeField] private string _itemName = "New Item";
        [SerializeField, TextArea] private string _description;
        [SerializeField] private Sprite _itemIcon = null;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private bool _isUnique = false;
        [SerializeField] private bool _isIndestructible = false;
        [SerializeField] private bool _isQuestItem = false;
        [SerializeField] private bool _destroyOnUse = false;

        public string ItemName => _itemName;
        public string Description => _description;
        public Sprite ItemIcon => _itemIcon;
        public GameObject Prefab => _prefab;
        public bool IsUnique => _isUnique;
        public bool IsIndestructible => _isIndestructible;
        public bool IsQuestItem => _isQuestItem;
        public bool DestroyOnUse => _destroyOnUse;
    }
}