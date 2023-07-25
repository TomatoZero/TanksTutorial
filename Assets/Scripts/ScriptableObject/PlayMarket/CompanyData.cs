using UnityEngine;

namespace TankTutorial.Scripts.ScriptableObject.PlayMarket
{
    [CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObject/PlayMarket/CompanyData", order = 0)]
    public class CompanyData : UnityEngine.ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _logo;
        [SerializeField] private string _email;
        [SerializeField] private string _website;
        [SerializeField] private string _address;
        [SerializeField] private string _urlPrivacyPolicy;

        public string Name => _name;

        public Sprite Logo => _logo;

        public string Email => _email;

        public string Website => _website;

        public string Address => _address;

        public string URLPrivacyPolicy => _urlPrivacyPolicy;
    }
}