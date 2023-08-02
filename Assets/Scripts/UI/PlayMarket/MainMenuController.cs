using System.Collections.Generic;
using System.Linq;
using TankTutorial.Scripts.UI.PlayMarket.Instance;
using UnityEngine;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private ProgramPageController _pageController;
        [SerializeField] private List<GameInfo> _games;
        [SerializeField] private GameWithExampleController _firstWithExample;
        [SerializeField] private GameWithExampleController _secondWithExample;
        [SerializeField] private GameWithExampleController _thirstWithExample;
        [SerializeField] private SuggestedGamesController _suggestedGames;
        [SerializeField] private GameContainerController _firstContainer;
        [SerializeField] private GameContainerController _secondContainer;

        private void Start()
        {
            _firstWithExample.SetData(_games[4], _pageController);
            _secondWithExample.SetData(_games[1], _pageController);
            _thirstWithExample.SetData(_games[5], _pageController);

            _suggestedGames.SetData("For you", _games);
            _firstContainer.SetData(_games.ToArray(), _pageController);
            _secondContainer.SetData(_games.ToArray(), _pageController);
        }
    }
}