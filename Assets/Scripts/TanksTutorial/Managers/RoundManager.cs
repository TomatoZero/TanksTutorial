using System.Collections;
using TankTutorial.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TankTutorial.Managers
{
    public class RoundManager : MonoBehaviour
    {
        [SerializeField] private int _numRoundToWin = 1;
        [SerializeField] private float _startDelay = 3;
        [SerializeField] private float _endDelay = 3;

        [SerializeField] private SpawnersManager _spawnersManager;
        [SerializeField] private UIManager _uiManager;

        private int _currentRound;
        private TankManager _roundWinner;
        private TankManager _gameWinner;
        private WaitForSeconds _startWait;
        private WaitForSeconds _endWait;


        private void Start()
        {
            _startWait = new WaitForSeconds(_startDelay);
            _endWait = new WaitForSeconds(_endDelay);

            _spawnersManager.SpawnAllTanks();

            StartCoroutine(GameLoop());
        }

        private IEnumerator GameLoop()
        {
            yield return StartCoroutine(RoundStarting());

            yield return StartCoroutine(RoundPlaying());

            yield return StartCoroutine(RoundEnding());

            if (_gameWinner != null)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                StartCoroutine(GameLoop());
            }
        }


        private IEnumerator RoundStarting()
        {
            _spawnersManager.ResetAllTanks();
            _spawnersManager.DisableTankControl();

            _currentRound++;

            _uiManager.ShowMessage($"Round {_currentRound}");

            yield return _startWait;
        }


        private IEnumerator RoundPlaying()
        {
            _spawnersManager.EnableTankControl();
            _uiManager.HideMessage();

            while (!_spawnersManager.OneTankLeft())
            {
                yield return null;
            }
        }


        private IEnumerator RoundEnding()
        {
            _spawnersManager.DisableTankControl();

            _roundWinner = null;
            _roundWinner = _spawnersManager.GetRoundWinner();

            if (_roundWinner != null)
                _roundWinner.Wins++;

            _gameWinner = _spawnersManager.GetGameWinner(_numRoundToWin);

            string message = EndMessage();
            _uiManager.ShowMessage(message);

            yield return _endWait;
        }

        private string EndMessage()
        {
            string message = "DRAW!";

            if (_roundWinner != null)
                message = _roundWinner.ColoredPlayerText + " WINS THE ROUND!";

            message += "\n\n\n\n";

            message += _spawnersManager.GetScore();

            if (_gameWinner != null)
            {
                message = _gameWinner.ColoredPlayerText + " WINS THE GAME!";
                var gameSum = GetRoundSum();
                JsonSerializer.Save("statistic", gameSum);
            }

            return message;
        }

        private RoundSum GetRoundSum()
        {
            var firstPlayerWins = _spawnersManager.GetScore(0);
            var secondPlayerWins = _spawnersManager.GetScore(1);

            var output = new RoundSum();
            output.InsertValue(firstPlayerWins, secondPlayerWins);

            return output;
        }
    }
}