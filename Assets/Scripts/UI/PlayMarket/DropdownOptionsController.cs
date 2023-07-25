using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class DropdownOptionsController : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _dropdown;
        [SerializeField] private List<string> _list;

        private void OnEnable()
        {
            SetOptions(_list);
        }

        public void SetOptions(List<string> options)
        {
            _dropdown.options.Clear();
            foreach (var option in options)
            {
                _dropdown.options.Add(new TMP_Dropdown.OptionData(option));
            }
        }
    }
}