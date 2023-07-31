using System;
using System.Globalization;
using TankTutorial.Scripts.ScriptableObject.PlayMarket;
using TankTutorial.Scripts.UI.PlayMarket.Instance;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class GameButtonController : MonoBehaviour
    {
        [SerializeField] private ProgramPageController _pageController; 
        [SerializeField] private Image _ico;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _rate;
        [SerializeField] private TMP_Text _price;

        [SerializeField] private GameInfo _gameData;
        
        private void Start()
        {
            // SetData();
        }

        public void SetData(GameInfo gameData)
        {
            _gameData = gameData;
            SetData();
        }
        
        public void SetData(GameInfo gameData, ProgramPageController pageController)
        {
            _gameData = gameData;
            _pageController = pageController;
            SetData();
        }

        public void Click()
        {
            _pageController.NextPage(_gameData);
        }
        
        private void SetData()
        {
            _ico.sprite = _gameData.GameData.Ico;
            _name.text = _gameData.GameData.Name;
            _rate.text = _gameData.GameData.Rate.ToString(CultureInfo.InvariantCulture);
            
            if(_gameData.GameData.Price == 0) return;
            
            _price.text = _gameData.GameData.Price.ToString(CultureInfo.CurrentCulture);
        }
    }
}