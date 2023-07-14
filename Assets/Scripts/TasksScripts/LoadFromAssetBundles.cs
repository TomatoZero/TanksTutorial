using System;
using System.IO;
using TankTutorial.Scripts.TaskScripts.Particles;
using UnityEngine;

namespace TankTutorial.Scripts.TaskScripts
{
    public class LoadFromAssetBundles : MonoBehaviour
    {
        [SerializeField] private WeaponsController _weaponParent;

        private string _weaponAssetBundlePath;
        private string _weaponAssetBundleFolderPath;
        private string _assetBundlePath;
        
        private void OnEnable()
        {
            _assetBundlePath = Path.Combine(Application.streamingAssetsPath, "AssetBundles", "AssetBundles");
            _weaponAssetBundlePath = Path.Combine(Application.streamingAssetsPath, "AssetBundles", "weaponsassetbundle");
            _weaponAssetBundleFolderPath = Path.Combine(Application.streamingAssetsPath, "AssetBundles");
        }

        void Start() {
            LoadDependencies("weaponsassetbundle");
            var weaponAb = AssetBundle.LoadFromFile(_weaponAssetBundlePath); 
            
            if (weaponAb == null) {
                Debug.Log("Failed to load AssetBundle!");
                return;
            }
            CreateInstant(weaponAb, "FireSword");
            CreateInstant(weaponAb, "FrostSword");
        }

        private AssetBundle LoadDependencies(string dependenciesFor)
        {
            var weaponManifest = AssetBundle.LoadFromFile(_assetBundlePath);
            var manifest = weaponManifest.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
            
            var dependencies = manifest.GetAllDependencies(dependenciesFor);
            foreach(var dependency in dependencies)
            {
                AssetBundle.LoadFromFile(Path.Combine(_weaponAssetBundleFolderPath, dependency));
            }

            return weaponManifest;
        }

        private void CreateInstant(AssetBundle myLoadedAssetBundle, string fileName)
        {
            var prefab = myLoadedAssetBundle.LoadAsset<GameObject>(fileName);
            _weaponParent.AddWeapon(prefab);
        }
    }
}