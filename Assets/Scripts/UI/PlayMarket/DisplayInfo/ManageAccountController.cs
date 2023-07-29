using TankTutorial.Scripts.UI.PlayMarket.Instance;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class ManageAccountController : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _nickName;
        [SerializeField] private TMP_Text _email;
        [SerializeField] private AccountInfo _info;

        public void SetData(AccountInfo info)
        {
            _info = info;
            SetData();
        }

        private void SetData()
        {
            _image.sprite = _info.Account.Avatar;
            _nickName.text = _info.Account.NickName;
            _email.text = _info.Account.Email;
        }
    }
}