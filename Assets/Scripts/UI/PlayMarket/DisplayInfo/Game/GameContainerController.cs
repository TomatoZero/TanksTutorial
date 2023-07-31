using System.Collections.Generic;
using TankTutorial.Scripts.ScriptableObject.PlayMarket;
using TankTutorial.Scripts.UI.PlayMarket.Instance;
using TMPro;
using UnityEngine;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class GameContainerController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _containerName;
        [SerializeField] private List<GameGroupController> _groupControllers;

        private ProgramPageController _pageController;
        private GameInfo[] _games = new GameInfo[6];

        public void SetData(GameInfo[] games, ProgramPageController pageController ,string categoryName = "Suggested for you")
        {
            _games = games;
            _containerName.text = categoryName;
            _pageController = pageController;
            SetData();
        }

        private void SetData()
        {
            for (int i = 0; i < _games.Length; i += 3)
            {
                var group = new[] { _games[i], _games[i + 1], _games[i + 2] };
                _groupControllers[i / 3].SetData(group, _pageController);
            }
        }
    }
}