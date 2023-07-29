using System.Collections.Generic;
using TankTutorial.Scripts.ScriptableObject.PlayMarket;
using UnityEngine;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class GameGroupController : MonoBehaviour
    {
        [SerializeField] private List<GameButtonController> _gameButtons;

        private List<GameData> _games;

        public void SetData(List<GameData> games)
        {
            _games = games;
        }

        private void SetData()
        {
            for (int i = 0; i < _gameButtons.Count; i++)
            {
                _gameButtons[i].SetData(_games[i]);
            }
        }
    }
}