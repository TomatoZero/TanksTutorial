using System.IO;
using TankTutorial.Scripts.TaskScripts.Particles;
using UnityEngine;

namespace TankTutorial.Scripts.TaskScripts
{
    public class LoadFromAssetBundles : MonoBehaviour
    {
        [SerializeField] private WeaponsController _weaponParent;
        
        void Start() {
            
            var materialsAb 
                = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "AssetBundles" , "material" ,"particlematerial"));
            
            var weaponAb 
                = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "AssetBundles" , "weaponsassetbundle"));
            
            if (weaponAb == null) {
                Debug.Log("Failed to load AssetBundle!");
                return;
            }
            CreateInstant(weaponAb, "FireSword");
            CreateInstant(weaponAb, "FrostSword");
        }

        private void CreateInstant(AssetBundle myLoadedAssetBundle, string fileName)
        {
            var prefab = myLoadedAssetBundle.LoadAsset<GameObject>(fileName);
            _weaponParent.AddWeapon(prefab);
        }
    }
}