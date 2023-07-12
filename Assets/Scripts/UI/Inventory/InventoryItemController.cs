using TankTutorial.Scripts.ScriptableObject;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    [SerializeField] private Image _itemIco;
    [SerializeField] private TMP_Text _count;
    
    private InventoryItem _item;
    private int _currentCount;
    
    public void SetItemData(InventoryItem item)
    {
        _item = item;
        DisableCountIfNeed();
        _currentCount = _item.StackMaxCount;
        ReloadData();
    }

    public void ReloadData()
    {
        _itemIco.sprite = _item.ItemIcon;
        _count.text = _currentCount.ToString();
    }

    private void DisableCountIfNeed()
    {
        if (!_item.IsStackable)
            _count.enabled = false;
    }
}