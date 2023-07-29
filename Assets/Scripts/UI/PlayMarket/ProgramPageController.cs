using TankTutorial.Scripts.UI.PlayMarket.Instance;
using UnityEngine;
using UnityEngine.UI;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class ProgramPageController : MonoBehaviour
    {
        [SerializeField] private GameInfo _game;
        [Space]
        [SerializeField] private GameInfoController _gameInfo;
        [SerializeField] private GameObject _whatNew;
        [SerializeField] private ContactsController _contacts;
        [SerializeField] private AboutGameController _aboutGame;
        [SerializeField] private RatingController _ratingController;
        
        private void SetData()
        {
            _gameInfo.SetData(_game);
            
            if(_game.IsInstalled) _whatNew.SetActive(true);
            else _whatNew.SetActive(false);
            
            _aboutGame.SetData(_game);
            _contacts.SetData(_game.GameData.Company);
            _ratingController.SetData(_game.GameData);
        }
    }
}