using UnityEngine;

namespace TankTutorial.Scripts.ScriptableObject.PlayMarket
{
    [CreateAssetMenu(fileName = "AccountData", menuName = "ScriptableObject/PlayMarket/AccountData")]
    public class AccountData : UnityEngine.ScriptableObject
    {
        [SerializeField] private string _nickName;
        [SerializeField] private string _email;
        [SerializeField] private Sprite _avatar;

        public string NickName => _nickName;

        public string Email => _email;

        public Sprite Avatar => _avatar;
    }
}