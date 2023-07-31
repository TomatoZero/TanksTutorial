using TankTutorial.Scripts.ScriptableObject.PlayMarket;
using TankTutorial.Scripts.UI.PlayMarket.Instance;
using UnityEngine;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class GameGroupController : MonoBehaviour
    {
        [SerializeField] private GameButtonController[] _gameButtons;

        private ProgramPageController _pageController;
        private GameInfo[] _games;

        public void SetData(GameInfo[] games, ProgramPageController pageController)
        {
            _games = games;
            _pageController = pageController;
            SetData();
        }

        private void SetData()
        {
            if (_games.Length != _gameButtons.Length) return;
            for (int i = 0; i < _gameButtons.Length; i++)
            {
                if (_games[i] != null) _gameButtons[i].SetData(_games[i], _pageController);
            }
        }
    }
}