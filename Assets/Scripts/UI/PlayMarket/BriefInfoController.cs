using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class BriefInfoController : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _infoTMP;
        [SerializeField] private TMP_Text _textTMP;
        [Space] [SerializeField] private Sprite _ico;
        [SerializeField] private string _info;
        [SerializeField] private bool _useImage;
        [SerializeField] private string _text;

        private void Start()
        {
            SetData(_info, _text);
        }
        
        public void SetData(string info, string additionInfo)
        {
            SetInputDataData(info, additionInfo);
        }

        public void SetData(string info)
        {
            SetInputDataData(info, "");
        }

        private void SetInputDataData(string info, string additionInfo)
        {
            _infoTMP.text = info;
            if (additionInfo == "")
            {
                _image.gameObject.SetActive(true);
                _image.sprite = _ico;
                _textTMP.text = "";
            }
            else
            {
                _image.gameObject.SetActive(false);
                _textTMP.text = additionInfo;
            }
        }
    }
}