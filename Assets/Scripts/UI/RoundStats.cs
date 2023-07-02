using TMPro;
using UnityEngine;

namespace TankTutorial.Scripts.UI
{
    public class RoundStats : MonoBehaviour
    {
        [SerializeField] private TMP_Text _winner;
        [SerializeField] private TMP_Text _firstPlayerScore;
        [SerializeField] private TMP_Text _secondPlayerScore;
        [SerializeField] private TMP_Text _date;

        public void Insert(string winner, string firstPlayerScore, string secondPlayerScore, string date)
        {
            _winner.text = winner;
            _firstPlayerScore.text = firstPlayerScore;
            _secondPlayerScore.text = secondPlayerScore;
            _date.text = date;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}