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
        [SerializeField] private GameExampleController _exampleController;
        [SerializeField] private Transform _genresContainer;
        [SerializeField] private GameObject _genrePrefab;

        private GameInfo _gameInfo;

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
            _exampleController.SetData(_gameInfo.GameData);
            SetGenres();
        }

        private void SetGenres()
        {
            ClearChildren();
            InstantiateGenreButtons();
        }

        private void ClearChildren()
        {
            foreach (Transform child in _genresContainer) {
                Destroy(child.gameObject);
            }
        }

        private void InstantiateGenreButtons()
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