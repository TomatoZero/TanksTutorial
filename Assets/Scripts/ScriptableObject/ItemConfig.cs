using UnityEngine;
using UnityEngine.Serialization;

namespace TankTutorial.Scripts.ScriptableObject
{
    [CreateAssetMenu(fileName = "ItemConfig", menuName = "ScriptableObject/ItemConfig", order = 0)]
    public class ItemConfig : UnityEngine.ScriptableObject
    {
        [FormerlySerializedAs("_bulletConfig")] [SerializeField] private ItemData[] _items;

        public ItemData[] Items => _items;
    }
}