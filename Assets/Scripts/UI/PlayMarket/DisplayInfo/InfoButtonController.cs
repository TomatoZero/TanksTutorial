using TankTutorial.Scripts.ScriptableObject.PlayMarket;
using TankTutorial.Scripts.UI.PlayMarket.Instance;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class InfoButtonController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _additionInfo;

        private string _url;
        private string _addition;
        
        public void OpenUrl()
        {
            Debug.Log($"open url {_url}");
        }

        public void SetData(string url, string info)
        {
            _url = url;
            _addition = info;
            SetData();
        }

        private void SetData()
        {
            if (_addition == "") _additionInfo.gameObject.SetActive(false);
            else
            {
                _additionInfo.gameObject.SetActive(true);
                _additionInfo.text = _addition;
            }
        }
    }
}