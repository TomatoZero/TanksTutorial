using System;
using System.Globalization;
using TankTutorial.Scripts.ScriptableObject.PlayMarket;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class GameButtonController : MonoBehaviour
    {
        [SerializeField] private Image _ico;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _rate;
        [SerializeField] private TMP_Text _price;

        [SerializeField] private GameData _gameData;

        private void Start()
        {
            // SetData();
        }

        public void SetData(GameData gameData)
        {
            _gameData = gameData;
            SetData();
        }
        
        private void SetData()
        {
            _ico.sprite = _gameData.Ico;
            _name.text = _gameData.Name;
            _rate.text = _gameData.Rate.ToString(CultureInfo.InvariantCulture);
            _price.text = _gameData.Price.ToString(CultureInfo.CurrentCulture);
        }
    }
}