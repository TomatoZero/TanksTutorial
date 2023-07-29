using TankTutorial.Scripts.UI.PlayMarket.Instance;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class GameInfoController : MonoBehaviour
    {
        [SerializeField] private Image _ico;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _companyName;
        [SerializeField] private TMP_Text _additionInfo;
        [SerializeField] private Button _firstButton;
        [SerializeField] private Button _secondButton;
        [Space, SerializeField] private GameInfo _gameInfo;


        private void Start()
        {
            SetData();
        }

        public void SetData(GameInfo gameInfo)
        {
            _gameInfo = gameInfo;
        }

        private void SetData()
        {
            _ico.sprite = _gameInfo.GameData.Ico;
            _name.text = _gameInfo.GameData.Name;
            _companyName.text = _gameInfo.GameData.Company.Name;
            _additionInfo.text = _gameInfo.GameData.AdditionInfo;

            if (_gameInfo.IsInstalled)
            {
                _firstButton.name = "Uninstall";
                _secondButton.name = "Play";
                _secondButton.gameObject.SetActive(true);
            }
            else
            {
                _secondButton.gameObject.SetActive(false);
                if (_gameInfo.GameData.Price == 0) _firstButton.name = "Install";
                else _firstButton.name = $"Buy {_gameInfo.GameData.Price}";
            }
        }
    }
}