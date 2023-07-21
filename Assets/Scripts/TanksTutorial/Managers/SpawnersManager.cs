using System;
using System.Collections.Generic;
using System.Linq;
using TankTutorial.Scripts;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace TankTutorial.TankTutorial.Managers
{
    public class SpawnersManager : MonoBehaviour
    {
        [SerializeField] private List<TankManager> _tanks;
        [SerializeField] private AssetReference _tankReference;
        
        private readonly Queue<TankManager> _validTankManagers = new Queue<TankManager>();

        private readonly Dictionary<AssetReference, List<GameObject>> _spawnedTanks =
            new Dictionary<AssetReference, List<GameObject>>();
        
        private readonly Dictionary<AssetReference, AsyncOperationHandle<GameObject>> _asyncOperationHandles =
            new Dictionary<AssetReference, AsyncOperationHandle<GameObject>>();

        private readonly Dictionary<AssetReference, Queue<TankManager>> _queuedSpawnRequests =
            new Dictionary<AssetReference, Queue<TankManager>>();

        public event Action ResetEvent;
        public event Action EnableEvent;
        public event Action DisableEvent;

        public void Awake()
        {
            foreach (var manager in _tanks) _validTankManagers.Enqueue(manager);
        }

        public void Spawn(int count)
        {
            for (var i = 0; i < count; i++)
                Spawn();
        }

        public void Spawn()
        {
            if (!_tankReference.RuntimeKeyIsValid())
            {
                Debug.Log($"Invalid Key {_tankReference.RuntimeKey}");
                return;
            }

            if (_asyncOperationHandles.ContainsKey(_tankReference))
            {
                if (_asyncOperationHandles[_tankReference].IsDone)
                    SpawnTankFromLoadedReference(_tankReference, GetValidTankManager());
                else
                    EnqueueSpawnForAfterInitialization(_tankReference);
            }
            
            LoadAndSpawn();
        }

        private void LoadAndSpawn()
        {
            var handle = Addressables.LoadAssetAsync<GameObject>(_tankReference);
            _asyncOperationHandles[_tankReference] = handle;
            handle.Completed += HandleCompletedEvent;
        }

        private void HandleCompletedEvent(AsyncOperationHandle<GameObject> asyncOperationHandle)
        {
            if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
            {
                SpawnTankFromLoadedReference(_tankReference, GetValidTankManager());
                if (_queuedSpawnRequests.ContainsKey(_tankReference))
                {
                    while (_queuedSpawnRequests[_tankReference]?.Any() == true)
                    {
                        var manager = _queuedSpawnRequests[_tankReference].Dequeue();
                        SpawnTankFromLoadedReference(_tankReference, manager);
                    }
                }
            }
            else
            {
                Debug.LogError("AssetReference failed to load.");
            }
        }

        private void SpawnTankFromLoadedReference(AssetReference assetReference, TankManager manager)
        {
            assetReference.InstantiateAsync(manager.SpawnPoint.position, Quaternion.identity).Completed += InstantiateAsyncCompletedEvent;

            void InstantiateAsyncCompletedEvent(AsyncOperationHandle<GameObject> asyncOperationHandle)
            {
                manager.Instance = asyncOperationHandle.Result;
                manager.Setup();
            
                ResetEvent += manager.Reset;
                EnableEvent += manager.EnableControl;
                DisableEvent += manager.DisableControl;
                
                if (_spawnedTanks.ContainsKey(assetReference) == false) 
                    _spawnedTanks[assetReference] = new List<GameObject>();
                
                _spawnedTanks[assetReference].Add(asyncOperationHandle.Result);
                var notify = asyncOperationHandle.Result.AddComponent<NotifyOnDestroy>();
                notify.Destroyed += Remove;
                notify.AssetReference = assetReference;
            }
        }

        private void EnqueueSpawnForAfterInitialization(AssetReference assetReference)
        {
            if (!_queuedSpawnRequests.ContainsKey(assetReference))
                _queuedSpawnRequests[assetReference] = new Queue<TankManager>();
            _queuedSpawnRequests[assetReference].Enqueue(GetValidTankManager());
        }

        private void Remove(AssetReference assetReference, NotifyOnDestroy obj)
        {
            Addressables.ReleaseInstance(obj.gameObject);

            _spawnedTanks[assetReference].Remove(obj.gameObject);
            if (_spawnedTanks[assetReference].Count == 0)
            {
                Debug.Log($"Remove all {assetReference.RuntimeKey.ToString()}");

                if (_asyncOperationHandles[assetReference].IsValid())
                    Addressables.Release(_asyncOperationHandles[assetReference]);

                _asyncOperationHandles.Remove(assetReference);
            }
        }
        
        private void SpawnAllTanks()
        {
            for (int i = 0; i < _tanks.Count; i++)
            {
                _tanks[i].Instance = (GameObject)Instantiate(_tankReference.Asset, _tanks[i].SpawnPoint.position,
                    _tanks[i].SpawnPoint.rotation);
                _tanks[i].PlayerName = $"{i + 1}";
                _tanks[i].Setup();

                ResetEvent += _tanks[i].Reset;
                EnableEvent += _tanks[i].EnableControl;
                DisableEvent += _tanks[i].DisableControl;
            }
        }

        private TankManager GetValidTankManager()
        {
            return _validTankManagers.Dequeue();
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
                if (_tanks[i].Instance is not null)
                {
                    if (_tanks[i].Instance.activeSelf)
                        numTanksLeft++;
                }
            }

            return numTanksLeft <= 1;
        }

        public TankManager GetRoundWinner()
        {
            for (var i = 0; i < _tanks.Count; i++)
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