using TankTutorial.Scripts.Items;
using UnityEngine;

namespace TankTutorial.Scripts.ScriptableObject
{
    [CreateAssetMenu(fileName = "ItemConfigs", menuName = "ScriptableObject/ItemConfigs", order = 0)]
    public class ItemConfigs : UnityEngine.ScriptableObject
    {
        [SerializeField] private BulletData[] _bulletConfig;
        [SerializeField] private TurretData[] _turretsConfig;
        [SerializeField] private TrackData[] _tracksConfig;
    }
}