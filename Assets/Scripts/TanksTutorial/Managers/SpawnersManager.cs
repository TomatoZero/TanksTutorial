using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace TankTutorial.Managers
{
    public class SpawnersManager : MonoBehaviour
    {
        [SerializeField] private List<TankManager> _tanks;
        // [SerializeField] private GameObject _tankPrefab;
        [SerializeField] private AssetReference _tankReference;

        public event Action ResetEvent;
        public event Action EnableEvent;
        public event Action DisableEvent;

        void Start()
        {
            AsyncOperationHandle handle = _tankReference.LoadAssetAsync<GameObject>();
            handle.Completed += Handle_Completed;
        }

        private void Handle_Completed(AsyncOperationHandle obj)
        {
            if (obj.Status == AsyncOperationStatus.Succeeded)
            {
                SpawnAllTanks();
            }
            else
            {
                Debug.LogError("AssetReference failed to load.");
            }
        }

        public void SpawnAllTanks()
        {
            
            for (int i = 0; i < _tanks.Count; i++)
            {
                _tanks[i].Instance = (GameObject)Instantiate(_tankReference.Asset, _tanks[i].SpawnPoint.position, _tanks[i].SpawnPoint.rotation);
                _tanks[i].PlayerName = $"{i + 1}";
                _tanks[i].Setup();

                ResetEvent += _tanks[i].Reset;
                EnableEvent += _tanks[i].EnableControl;
                DisableEvent += _tanks[i].DisableControl;
            }
        }

        public void ResetAllTanks()
        {
            ResetEvent?.Invoke();
        }

        public void EnableTankControl()
        {
            EnableEvent?.Invoke();
        }

        public void DisableTankControl()
        {
            DisableEvent?.Invoke();
        }

        public bool OneTankLeft()
        {
            var numTanksLeft = 0;

            for (int i = 0; i < _tanks.Count; i++)
            {
                if (_tanks[i].Instance.activeSelf)
                    numTanksLeft++;
            }

            return numTanksLeft <= 1;
        }

        public TankManager GetRoundWinner()
        {
            for (int i = 0; i < _tanks.Count; i++)
            {
                if (_tanks[i].Instance.activeSelf)
                    return _tanks[i];
            }

            return null;
        }

        public TankManager GetGameWinner(int numRoundsToWin)
        {
            for (int i = 0; i < _tanks.Count; i++)
            {
                if (_tanks[i].Wins == numRoundsToWin)
                    return _tanks[i];
            }

            return null;
        }

        public string GetScore()
        {
            var message = "";
            for (int i = 0; i < _tanks.Count; i++)
            {
                message += _tanks[i].ColoredPlayerText + ": " + _tanks[i].Wins + " WINS\n";
            }

            return message;
        }

        public int GetScore(int i)
        {
            if (i < 0 || i >= _tanks.Count)
            {
                throw new IndexOutOfRangeException($"index {i}, list count: {_tanks.Count}");
            }

            return _tanks[i].Wins;
        }
    }
}