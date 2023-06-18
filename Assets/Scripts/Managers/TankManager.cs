using System;
using TankTutorial.Scripts.Player;
using UnityEngine;

namespace TankTutorial.Managers
{
    [Serializable]
    public class TankManager
    {
        [SerializeField] private Color _color;
        [SerializeField] private Transform _spawnPoint;

        private string _playerName;
        private string _coloredPlayerText;    
        private GameObject _instance;       
        private int _wins;

        private MovementController _movement;                       
        private ShootController _shooting;                       
        private GameObject _canvasGameObject;

        public string PlayerName
        {
            get => _playerName;
            set => _playerName = value;
        }

        public GameObject Instance
        {
            get => _instance;
            set => _instance = value;
        }

        public int Wins
        {
            get => _wins;
            set => _wins = value;
        }

        public string ColoredPlayerText => _coloredPlayerText;

        public Transform SpawnPoint => _spawnPoint;

        public void Setup ()
        {
            _movement = _instance.GetComponent<MovementController> ();
            _shooting = _instance.GetComponent<ShootController> ();
            _canvasGameObject = _instance.GetComponentInChildren<Canvas> ().gameObject;

            _coloredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(_color) + ">PLAYER " + _playerName + "</color>";
            
            var renderers = _instance.GetComponentsInChildren<MeshRenderer> ();
            foreach (var mesh in renderers) mesh.material.color = _color;
        }
        
        public void DisableControl ()
        {
            _movement.enabled = false;
            _shooting.enabled = false;

            _canvasGameObject.SetActive (false);
        }

        public void EnableControl ()
        {
            _movement.enabled = true;
            _shooting.enabled = true;

            _canvasGameObject.SetActive (true);
        }
        
        public void Reset ()
        {
            _instance.transform.position = _spawnPoint.position;
            _instance.transform.rotation = _spawnPoint.rotation;

            _instance.SetActive (false);
            _instance.SetActive (true);
        }
    }
}