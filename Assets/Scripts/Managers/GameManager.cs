using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TankTutorial.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private int _numRoundToWi = 5;
        [SerializeField] private float _startDelay = 3;
        [SerializeField] private float _endDelay = 3;
        [SerializeField] private TMP_Text _messageText;
        [SerializeField] private GameObject _tanksPrefab;
        [SerializeField] private List<TankManager> _tanks;

        private int _currentRound;
        private WaitForSeconds _startWait;         
        private WaitForSeconds _endWait;          
        private TankManager _roundWinner;          
        private TankManager _gameWinner;           

        
    }
}
