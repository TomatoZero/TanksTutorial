using TankTutorial.Scripts.Items;
using UnityEngine;

namespace TankTutorial.Scripts.ScriptableObject
{
    [CreateAssetMenu(fileName = "ItemConfig", menuName = "ScriptableObject/ItemConfig", order = 0)]
    public class ItemConfig : UnityEngine.ScriptableObject
    {
        [SerializeField] private BulletData[] _bulletConfig;
        [SerializeField] private TurretData[] _turretsConfig;
        [SerializeField] private TrackData[] _tracksConfig;
    }
}