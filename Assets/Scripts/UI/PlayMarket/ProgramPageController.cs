using System.Collections.Generic;
using TankTutorial.Scripts.UI.PlayMarket.Instance;
using UnityEngine;
using UnityEngine.UI;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class ProgramPageController : MonoBehaviour
    {
        [SerializeField] private GameInfo _game;
        [Space] [SerializeField] private GameInfoController _gameInfo;
        [SerializeField] private GameObject _whatNew;
        [SerializeField] private ContactsController _contacts;
        [SerializeField] private AboutGameController _aboutGame;
        [SerializeField] private RatingController _ratingController;
        [SerializeField] private SuggestedGamesController _suggestedGames;
        [SerializeField] private SuggestedGamesController _gamesLike;

        private Queue<GameInfo> _previousPage = new Queue<GameInfo>();

        private void Start()
        {
            SetData();
        }

        public void NextPage(GameInfo newGame)
        {
            _previousPage.Enqueue(_game);
            _game = newGame;
            
            SetData();
        }

        public void PrevPage()
        {
            if (_previousPage.TryDequeue(out GameInfo result))
            {
                _game = result;
                SetData();
            }
            else
            {
                CloseProgramPage();
            }
        }

        private void SetData()
        {
            _gameInfo.SetData(_game);

            if (_game.IsInstalled) _whatNew.SetActive(true);
            else _whatNew.SetActive(false);

            _aboutGame.SetData(_game);
            _contacts.SetData(_game.GameData.Company);
            _ratingController.SetData(_game.GameData);

            _suggestedGames.SetData("Similar Games", _game.SimilarGames);
            _gamesLike.SetData("Games Like", _game.GamesLikeThis);
            
            
        }

        private void CloseProgramPage()
        {
        }
    }
}