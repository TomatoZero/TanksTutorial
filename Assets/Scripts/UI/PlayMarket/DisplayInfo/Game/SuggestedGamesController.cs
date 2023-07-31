using System.Collections.Generic;
using TankTutorial.Scripts.ScriptableObject.PlayMarket;
using TankTutorial.Scripts.UI.PlayMarket.Instance;
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

        private List<GameInfo> _suggestedGame;

        public void SetData(string categoryName, List<GameInfo> games)
        {
            _categoryName.text = categoryName;
            _suggestedGame = games;
            SetData();
        }

        private void SetData()
        {
            if (_suggestedGame == null || _suggestedGame.Count == 0)
            {
                gameObject.SetActive(false);
                return;
            }
            
            ClearChildren();
            gameObject.SetActive(true);
            foreach (var gameData in _suggestedGame)
            {
                CreateInstance(gameData);
            }
        }

        private void ClearChildren()
        {
            foreach (Transform child in _gamesContainer)
            {
                Destroy(child.gameObject);
            }
        }
        
        private void CreateInstance(GameInfo game)
        {
            var instant = Instantiate(_gamePrefab, _gamesContainer);
            SetUpInstant(instant, game);
        }

        private void SetUpInstant(GameObject instant, GameInfo game)
        {
            var controller = instant.GetComponent<GameButtonController>();
            controller.SetData(game, _programPageController);
        }
    }
}