using System.Collections.Generic;
using TankTutorial.Scripts.ScriptableObject.PlayMarket;
using TMPro;
using UnityEngine;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class GameContainerController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _containerName;
        [SerializeField] private List<GameGroupController> _groupControllers;

        private List<GameData> _games;

        private void SetData()
        {
            for (int i = 0; i < _games.Count; i += 3)
            {
                
            }
        }
    }
}