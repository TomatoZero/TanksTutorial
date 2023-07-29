using System;
using TankTutorial.Scripts.UI.PlayMarket.Instance;
using UnityEngine;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class AdditionalInformationController : MonoBehaviour
    {
        [SerializeField] private BriefInfoController _rateAndCountReview;
        [SerializeField] private BriefInfoController _downloadAndCountReview;
        [SerializeField] private BriefInfoController _rate;
        [SerializeField] private BriefInfoController _numbDownloads;
        
        private GameInfo _gameInfo;

        public void SetData(GameInfo gameInfo)
        {
            _gameInfo = gameInfo;
        }

        private void SetData()
        {
            _rateAndCountReview.SetData(_gameInfo.GameData.Rate.ToString());
        }
    }
}