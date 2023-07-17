using System;
using TankTutorial.Scripts.ScriptableObject;
using UnityEngine;
using UnityEngine.UI;

namespace TankTutorial.Scripts.UI
{
    public class AddItem : MonoBehaviour
    {
        [SerializeField] private ItemData _itemData;
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;
        [SerializeField] private Inventory.Inventory _inventory;

        private void OnEnable()
        {
            _image.sprite = _itemData.ItemIcon;
            _button.onClick.AddListener(() => _inventory.Add(_itemData));
        }
    }
}