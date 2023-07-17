using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TankTutorial.Scripts
{
    public class NotifyOnDestroy : MonoBehaviour
    {
        public event Action<AssetReference, NotifyOnDestroy> Destroyed;

        public AssetReference AssetReference { get; set; }

        public void OnDestroy()
        {
            Destroyed?.Invoke(AssetReference, this);
        }
    }
}