using System;
using System.Collections.Generic;
using TankTutorial.Scripts.ScriptableObject.PlayMarket;
using UnityEngine;

namespace TankTutorial.Scripts.UI.PlayMarket.Instance
{
    [Serializable]
    public class AccountInfo
    {
        [SerializeField] private AccountData _account;
        [SerializeField] private List<GameInfo> _games;

        public AccountData Account => _account;

        public List<GameInfo> Games => _games;
    }
}