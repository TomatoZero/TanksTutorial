using System.Collections.Generic;
using TankTutorial.Scripts.ScriptableObject.PlayMarket;
using TMPro;
using UnityEngine;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class SuggestedGamesController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _categoryName;
        [SerializeField] private Transform _gamesContainer;
        [Space, SerializeField] private GameObject _gamePrefab;

        private List<GameData> _suggestedGame;

        public void SetData(List<GameData> games)
        {
            _suggestedGame = games;
            SetData();
        }
        
        private void SetData()
        {
            foreach (var gameData in _suggestedGame)
            {
                CreateInstance(gameData);
            }
        }

        private void CreateInstance(GameData game)
        {
            var instant = Instantiate(_gamePrefab, _gamesContainer).GetComponent<GameButtonController>();
            instant.SetData(game);
        }
    }
}