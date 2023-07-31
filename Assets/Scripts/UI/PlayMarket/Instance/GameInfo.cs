using System;
using System.Collections.Generic;
using TankTutorial.Scripts.ScriptableObject.PlayMarket;
using UnityEngine;

namespace TankTutorial.Scripts.UI.PlayMarket.Instance
{
    [Serializable]
    public class GameInfo
    {
        [SerializeField] private GameData _gameData;
        [SerializeField] private bool _isInstalled;
        [SerializeField] private List<GameInfo> _similarGames;
        [SerializeField] private List<GameInfo> _gamesLikeThis;


        public GameData GameData => _gameData;
        public bool IsInstalled => _isInstalled;
        public List<GameInfo> SimilarGames => _similarGames;
        public List<GameInfo> GamesLikeThis => _gamesLikeThis;

        public GameInfo() { }

        public GameInfo(GameData gameData, bool isInstalled)
        {
            _gameData = gameData;
            _isInstalled = isInstalled;
        }
    }
}