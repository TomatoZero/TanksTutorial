using TankTutorial.Scripts.UI.PlayMarket.Instance;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class InfoButtonController : MonoBehaviour
    {
        [SerializeField] private Image _ico;
        [SerializeField] private TMP_Text _categoryName;
        [SerializeField] private TMP_Text _additionInfo;

        private CompanyInfo _companyInfo;

        public void OpenUrl()
        {
            Debug.Log($"open url {_companyInfo.URL}");
        }

        public void SetData(CompanyInfo info)
        {
            _companyInfo = info;
            SetData();
        }

        public void SetData(Sprite sprite, string name, string info)
        {
            _companyInfo = new CompanyInfo(sprite, name, info);
            SetData();
        }

        public void SetData(Sprite sprite, string name)
        {
            _companyInfo = new CompanyInfo(sprite, name, "");
            SetData();
        }

        private void SetData()
        {
            _ico.sprite = _companyInfo.Sprite;
            _categoryName.text = _companyInfo.Category;

            if (_companyInfo.AdditionInfo == "") _additionInfo.gameObject.SetActive(false);
            else
            {
                _additionInfo.gameObject.SetActive(true);
                _additionInfo.text = _companyInfo.AdditionInfo;
            }
        }
    }
}