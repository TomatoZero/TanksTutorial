using System;
using TankTutorial.Scripts.UI.PlayMarket.Instance;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class AboutGameController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _aboutGame;
        [SerializeField] private AdditionalInformationController _additionalInformation;
        [SerializeField] private Transform _genresContainer;
        [SerializeField] private GameObject _genrePrefab;

        [SerializeField]private GameInfo _gameInfo;

        private void Start()
        {
            SetData();
        }

        public void SetData(GameInfo gameInfo)
        {
            _gameInfo = gameInfo;
            SetData();
        }

        private void SetData()
        {
            if (_gameInfo == null) return;

            _aboutGame.text = _gameInfo.GameData.AboutGame;
            _additionalInformation.SetData(_gameInfo);
            SetGenres();
        }

        private void SetGenres()
        {
            foreach (var genre in _gameInfo.GameData.Genre)
            {
                var button = Instantiate(_genrePrefab, _genresContainer).GetComponent<Button>();
                var text = button.GetComponentInChildren<TMP_Text>();
                text.text = genre;
            }
        }
    }
}