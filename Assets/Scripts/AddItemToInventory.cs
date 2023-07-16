using System.Collections.Generic;
using TankTutorial.Scripts.Inventory;
using TankTutorial.Scripts.Items;
using TankTutorial.Scripts.ScriptableObject;
using UnityEngine;
using UnityEngine.UI;

public class AddItemToInventory : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private List<ItemData> _items;
    [SerializeField] private Dropdown _dropdown;

    private void OnEnable()
    {
        // _dropdown.onValueChanged.AddListener(_inventory.Add(new BulletItem()));
        
        // _dropdown.options.Add(new Dropdown.OptionData());
    }

    public void AddItem(int id)
    {
        
    }
}
