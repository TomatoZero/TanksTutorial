using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TankTutorial.Scripts.TaskScripts.Particles;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;
using Object = UnityEngine.Object;

namespace TankTutorial.Scripts.TaskScripts
{
    public class LoadFromAssetBundles : MonoBehaviour
    {
        [SerializeField] private WeaponsController _weaponParent;
        [SerializeField] private AssetReference _assetReference;
        
        private string _weaponAssetBundlePath;
        private string _weaponAssetBundleFolderPath;
        private string _assetBundlePath;

        private List<AssetBundle> _assetBundles = new List<AssetBundle>();
        
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

            StartCoroutine(LoadFromSource());
        }

        private AssetBundle LoadFromDisk()
        {
            LoadDependencies("weaponsassetbundle");
            return AssetBundle.LoadFromFile(_weaponAssetBundlePath);
        }

        private IEnumerator LoadFromSource()
        {
            yield return StartCoroutine(GetAssetBundle("https://www.dropbox.com/scl/fi/wwfzhp62ko7708nva1cw4/particlematerial?rlkey=jcbiqq1i6fsgeocjt2c3qqnqk&dl=1"));

            _assetBundles[0].LoadAsset<GameObject>("FrostMaterial");
            _assetBundles[0].LoadAsset<GameObject>("Smoke");
            _assetBundles[0].LoadAsset<GameObject>("FireMaterial");
            _assetBundles[0].LoadAsset<GameObject>("Snowflake");
            
            yield return StartCoroutine(GetAssetBundle("https://www.dropbox.com/scl/fi/ekk1txwygame5vcjr4nse/particles?rlkey=9u1btzpovvvvvffl8eh69ighn&dl=1"));

            _assetBundles[1].LoadAsset<GameObject>("Frost");
            _assetBundles[1].LoadAsset<GameObject>("Fire");
            
            yield return StartCoroutine(GetAssetBundle("https://www.dropbox.com/scl/fi/l0gip0r54rlih4tyf8dzs/weaponsassetbundle?rlkey=8fzn562n1wv9rltg32nbi6xau&dl=1"));

            CreateInstant(_assetBundles[2], "FireSword");
            CreateInstant(_assetBundles[2], "FrostSword");
        }

        private IEnumerator GetAssetBundle(string source)
        { 
            var www = UnityWebRequestAssetBundle.GetAssetBundle(source);
            
            yield return www.SendWebRequest();

            if(www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError) {
                Debug.Log(www.error);
            }
            else {
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
                _assetBundles.Add(bundle);
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