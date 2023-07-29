using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class NumberVotersController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _numb;
        [SerializeField] private Slider _slider;

        private string _numberStr;
        private float _percentVoters;
        
        public void SetData(int numb, float percentVoters)
        {
            _numberStr = numb.ToString();
            _percentVoters = percentVoters;
            
            SetData();
        }

        private void SetData()
        {
            _numb.text = _numberStr;
            _slider.value = _percentVoters;
        }
    }
}