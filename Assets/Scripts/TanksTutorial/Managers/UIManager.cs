using TankTutorial.Scripts.UI;
using TMPro;
using UnityEngine;

namespace TankTutorial.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text _messageText;
        [SerializeField] private StatsController _statisticController;

        public void ShowMessage(string message)
        {
            _messageText.gameObject.SetActive(true);
            _messageText.text = message;
        }

        public void HideMessage()
        {
            _messageText.gameObject.SetActive(false);
        }

        public void ShowStatistic()
        {
            _statisticController.ShowStats("statistic");
        }

        public void HideStatistic()
        {
            _statisticController.HideStats();
        }
    }
}