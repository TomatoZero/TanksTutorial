using System;
using System.Collections;
using System.IO;
using TankTutorial.Scripts.TaskScripts.Particles;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using Object = UnityEngine.Object;

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

        void Start()
        {
            // var weaponAb = LoadFromDisk();
            //
            // if (weaponAb == null) {
            //     Debug.Log("Failed to load AssetBundle!");
            //     return;
            // }
            // CreateInstant(weaponAb, "FireSword");
            // CreateInstant(weaponAb, "FrostSword");
            
            StopCoroutine(GetAssetBundle());
        }

        private AssetBundle LoadFromDisk()
        {
            LoadDependencies("weaponsassetbundle");
            return AssetBundle.LoadFromFile(_weaponAssetBundlePath);
        }

        private AssetBundle LoadFromSource()
        {
            StopCoroutine(GetAssetBundle());
            return default;
        }

        private IEnumerator GetAssetBundle()
        { 
            var www = UnityWebRequestAssetBundle.GetAssetBundle(
                "https://www.dropbox.com/scl/fi/l0gip0r54rlih4tyf8dzs/weaponsassetbundle?rlkey=8fzn562n1wv9rltg32nbi6xau&dl=0");
            
            yield return www.SendWebRequest();

            if(www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError) {
                Debug.Log(www.error);
            }
            else {
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);

                var cube = bundle.LoadAsset("FireSword");
               
                CreateInstant(cube.GameObject());
            }
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

        private void CreateInstant(GameObject obj)
        {
            _weaponParent.AddWeapon(obj);

        }
    }
}