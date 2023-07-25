using System.Collections.Generic;
using UnityEngine;

namespace TankTutorial.Scripts.ScriptableObject.PlayMarket
{
    [CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObject/PlayMarket/GameData", order = 0)]
    public class GameData : UnityEngine.ScriptableObject
    {
        [SerializeField] private CompanyData _company;
        [SerializeField] private string _name;
        [SerializeField] private Sprite _ico;
        [Space]
        [SerializeField] private List<Sprite> _gameExamples;
        [SerializeField] private float _price;
        [Space]
        [SerializeField, Range(0, 5)] private float _rate;
        [SerializeField] private List<int> _rates;
    }
}