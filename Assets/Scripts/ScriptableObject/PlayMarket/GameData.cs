using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace TankTutorial.Scripts.ScriptableObject.PlayMarket
{
    [CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObject/PlayMarket/GameData", order = 0)]
    public class GameData : UnityEngine.ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private CompanyData _company;
        [SerializeField] private Sprite _ico;
        [SerializeField] private string _additionInfo;
        [SerializeField, TextArea] private string _aboutGame;
        [SerializeField] private List<String> _genre;
        [Space] [SerializeField] private Sprite _mainExample;
        [SerializeField] private List<Sprite> _gameExamples;
        [SerializeField] private float _price;
        [Space] [SerializeField, Range(0, 5)] private float _rate;
        [SerializeField] private List<int> _rates;

        public string Name => _name;

        public CompanyData Company => _company;

        public Sprite Ico => _ico;

        public string AdditionInfo => _additionInfo;

        public string AboutGame => _aboutGame;

        public List<string> Genre => _genre;

        public Sprite MainExample => _mainExample;

        public List<Sprite> GameExamples => _gameExamples;

        public float Price => _price;

        public float Rate => _rate;

        public List<int> Rates => _rates;
    }
}