using TankTutorial.Scripts.ScriptableObject.PlayMarket;
using UnityEngine;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class ContactsController : MonoBehaviour
    {
        [SerializeField] private InfoButtonController _web;
        [SerializeField] private InfoButtonController _email;
        [SerializeField] private InfoButtonController _address;
        [SerializeField] private InfoButtonController _privacyPolicy;

        private CompanyData _company;

        public void SetData(CompanyData company)
        {
            _company = company;
            SetData();
        }

        private void SetData()
        {
            _web.SetData(_company.Website, "");
            _email.SetData(_company.Email, _company.Email);
            _address.SetData(_company.Address, _company.Address);
            _privacyPolicy.SetData(_company.URLPrivacyPolicy, "");
        }
    }
}