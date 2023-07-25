using System;
using UnityEngine;

namespace TankTutorial.Scripts.UI.PlayMarket.Instance
{
    [Serializable]
    public class CompanyInfo
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private string _category;
        [SerializeField] private string _additionInfo;
        [SerializeField] private string _url;

        public Sprite Sprite => _sprite;

        public string Category => _category;

        public string AdditionInfo => _additionInfo;

        public string URL => _url;

        public CompanyInfo(Sprite sprite, string category, string additionInfo)
        {
            _sprite = sprite;
            _category = category;
            _additionInfo = additionInfo;
        }

        public CompanyInfo(Sprite sprite, string category, string additionInfo, string url)
        {
            _sprite = sprite;
            _category = category;
            _additionInfo = additionInfo;
            _url = url;
        }
    }
}