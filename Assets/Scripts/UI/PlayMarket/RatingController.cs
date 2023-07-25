using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class RatingController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _rate;
        [SerializeField] private Slider _starsCount;
        
        [SerializeField] private List<NumberVotersController> _votersControllers;

        [SerializeField] private List<float> _numbVoters;

        private void Start()
        {
            for (int i = 0; i < _votersControllers.Count; i++)
            {
                SetDataIn(i, _numbVoters[i]);
            }
            
            SetTotalRate(4.5f);
        }

        public void SetTotalRate(float rate)
        {
            _rate.text = rate.ToString();
            _starsCount.value = rate;
        }
        
        public void SetDataIn(int numb, float numberVoters)
        {
            if (numb < 0 || numb >= _votersControllers.Count) return;
            else _votersControllers[numb].SetData(numb, numberVoters);
        }
    }
}