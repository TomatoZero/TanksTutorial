using TMPro;
using UnityEngine;

namespace TankTutorial.Scripts.TaskScripts
{
    public class BoxScript : MonoBehaviour
    {
        [SerializeField] private TMP_Text _countPassThrough;

        private int _count;

        private void OnTriggerExit(Collider other)
        {
            _count++;
            _countPassThrough.text = $"Pass Through {_count}";
        }
    }
}