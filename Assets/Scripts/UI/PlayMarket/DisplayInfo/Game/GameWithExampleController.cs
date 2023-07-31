using TankTutorial.Scripts.ScriptableObject.PlayMarket;
using TankTutorial.Scripts.UI.PlayMarket.Instance;
using UnityEngine;
using UnityEngine.UI;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class GameWithExampleController : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private GameButtonController _buttonController;

        private GameInfo _game;
        private ProgramPageController _pageController;
        
        public void SetData(GameInfo game)
        {
            _game = game;
            SetData();
        }

        public void SetData(GameInfo game, ProgramPageController pageController)
        {
            _game = game;
            _pageController = pageController;
            SetData();
        }

        private void SetData()
        {
            _image.sprite = _game.GameData.MainExample;
            if(_pageController != null) _buttonController.SetData(_game, _pageController);
            else _buttonController.SetData(_game);
        }
    }
}