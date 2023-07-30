using System.Collections.Generic;
using TankTutorial.Scripts.ScriptableObject.PlayMarket;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class SuggestedGamesController : MonoBehaviour
    {
        [SerializeField] private ProgramPageController _programPageController;
        [SerializeField] private TMP_Text _categoryName;
        [SerializeField] private Transform _gamesContainer;
        [Space, SerializeField] private GameObject _gamePrefab;

        private List<GameData> _suggestedGame;

        public void SetData(string categoryName, List<GameData> games)
        {
            _categoryName.text = categoryName;
            _suggestedGame = games;
            SetData();
        }

        private void SetData()
        {
            if (_suggestedGame == null)
            {
                gameObject.SetActive(false);
                return;
            }
            
            foreach (var gameData in _suggestedGame)
            {
                CreateInstance(gameData);
            }
        }

        private void CreateInstance(GameData game)
        {
            var instant = Instantiate(_gamePrefab, _gamesContainer);

            var controller = instant.GetComponent<GameButtonController>();
            controller.SetData(game, _programPageController);

            var button = instant.GetComponent<Button>();
            button.onClick.AddListener(controller.Click);
        }
    }
}