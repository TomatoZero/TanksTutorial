using System.Collections.Generic;
using TankTutorial.Scripts.UI.PlayMarket.Instance;
using UnityEngine;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class ContactsController : MonoBehaviour
    {
        [SerializeField] private List<InfoButtonController> _controllers;

        [SerializeField] private List<CompanyInfo> _companyInfos;

        public void Start()
        {
            for (int i = 0; i < _controllers.Count; i++)
            {
                SetInfoIn(_companyInfos[i], i);
            }
        }

        public void SetInfoIn(CompanyInfo info, int number)
        {
            if (number < 0 || number >= _controllers.Count)
                return;

            _controllers[number].SetData(info);
        }
    }
}