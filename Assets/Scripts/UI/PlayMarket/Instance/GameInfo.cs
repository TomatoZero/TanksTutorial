using System;
using TankTutorial.Scripts.ScriptableObject.PlayMarket;
using UnityEngine;
using UnityEngine.Serialization;

namespace TankTutorial.Scripts.UI.PlayMarket.Instance
{
    [Serializable]
    public class GameInfo
    {
        [SerializeField] private GameData _gameData;
        [SerializeField] private bool _isInstalled;

        public GameData GameData => _gameData;

        public bool IsInstalled => _isInstalled;
    }
}