using TMPro;
using UnityEngine;

namespace TankTutorial.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text _messageText;

        public void ShowMessage(string message)
        {
            gameObject.SetActive(true);
            _messageText.text = message;
        }

        public void HideMessage()
        {
            gameObject.SetActive(false);
        }
        
        // private string EndMessage()
        // {
        //     // // By default when a round ends there are no winners so the default end message is a draw.
        //     // string message = "DRAW!";
        //     //
        //     // // If there is a winner then change the message to reflect that.
        //     // if (m_RoundWinner != null)
        //     //     message = m_RoundWinner.m_ColoredPlayerText + " WINS THE ROUND!";
        //     //
        //     // // Add some line breaks after the initial message.
        //     // message += "\n\n\n\n";
        //     //
        //     // // Go through all the tanks and add each of their scores to the message.
        //     // for (int i = 0; i < m_Tanks.Length; i++)
        //     // {
        //     //     message += m_Tanks[i].m_ColoredPlayerText + ": " + m_Tanks[i].m_Wins + " WINS\n";
        //     // }
        //     //
        //     // // If there is a game winner, change the entire message to reflect that.
        //     // if (m_GameWinner != null)
        //     //     message = m_GameWinner.m_ColoredPlayerText + " WINS THE GAME!";
        //     //
        //     // return message;
        // }
    }
}