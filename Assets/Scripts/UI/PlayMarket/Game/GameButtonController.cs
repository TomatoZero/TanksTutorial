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

        private GameData _gameData;
        
        private void Start()
        {
            // SetData();
        }

        public void SetData(GameData gameData)
        {
            _gameData = gameData;
            SetData();
        }
        
        public void SetData(GameData gameData, ProgramPageController pageController)
        {
            _gameData = gameData;
            _pageController = pageController;
            SetData();
        }

        public void Click()
        {
            _pageController.NextPage(new GameInfo(_gameData, false));
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