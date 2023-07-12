using UnityEngine;

namespace TankTutorial.Scripts.ScriptableObject
{
    [CreateAssetMenu(fileName = "InventoryItem", menuName = "ScriptableObject/InventoryItem", order = 0)]
    public class InventoryItem : UnityEngine.ScriptableObject
    {
        [SerializeField] private string _itemName = "New Item";
        [SerializeField] private Sprite _itemIcon = null;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private bool _isUnique = false;
        [SerializeField] private bool _isIndestructible = false;
        [SerializeField] private bool _isQuestItem = false;
        [SerializeField] private bool _isStackable = false;
        [SerializeField] private int _stackMaxCount = 0;
        [SerializeField] private bool _destroyOnUse = false;

        public string ItemName => _itemName;
        public Sprite ItemIcon => _itemIcon;
        public GameObject Prefab => _prefab;
        public bool IsUnique => _isUnique;
        public bool IsIndestructible => _isIndestructible;
        public bool IsQuestItem => _isQuestItem;
        public bool IsStackable => _isStackable;
        public int StackMaxCount => _stackMaxCount;
        public bool DestroyOnUse => _destroyOnUse;
    }
}