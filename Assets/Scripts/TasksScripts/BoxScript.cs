using TMPro;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    [SerializeField] private TMP_Text _countPassThrough;

    private int _count;
    
    private void OnCollisionEnter(Collision other)
    {
        Physics.IgnoreLayerCollision(gameObject.layer, other.gameObject.layer);
    }

    private void OnCollisionExit(Collision other)
    {
        Physics.IgnoreLayerCollision(gameObject.layer, other.gameObject.layer);
        _count++;
        _countPassThrough.text = $"Pass Through {_count}";
    }

    private void OnCollisionStay(Collision other)
    {
        Debug.Log("3");
    }
}