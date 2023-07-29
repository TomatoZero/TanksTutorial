using System.Collections.Generic;
using TankTutorial.Scripts.ScriptableObject.PlayMarket;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class RatingController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _rate;
        [SerializeField] private Slider _starsCount;

        [SerializeField] private List<NumberVotersController> _votersControllers;

        private GameData _gameData;

        public void SetData(GameData game)
        {
            _gameData = game;
            SetData();
        }

        private void SetData()
        {
            if (_gameData.Rates.Count == 5 && _votersControllers.Count == 5)
            {
                for (int i = 0; i < _votersControllers.Count; i++) SetDataIn(i, _gameData.Rates[i]);
                SetTotalRate(_gameData.Rate);
            }
        }

        private void SetTotalRate(float rate)
        {
            _rate.text = rate.ToString();
            _starsCount.value = rate;
        }

        private void SetDataIn(int numb, float numberVoters)
        {
            if (numb < 0 || numb >= _votersControllers.Count) return;
            else _votersControllers[numb].SetData(numb, numberVoters);
        }
    }
}