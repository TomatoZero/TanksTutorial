using System;
using TankTutorial.Scripts.Player;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    [SerializeField] private HealthController _healthController;
    [SerializeField] private Transform _playerTransform;

    [SerializeField] private Rigidbody _rigidbody;
    // [SerializeField] private TankManager _tankManager;

    private void Awake()
    {
        LoadDataEventHandler();
        Debug.Log(Application.persistentDataPath);
    }

    public void SaveDataEventHandler()
    {
        PlayerPrefs.SetInt("Health", _healthController.CurrentHp);
        
        var position = _playerTransform.position;
        PlayerPrefs.SetFloat("XPos", position.x);
        PlayerPrefs.SetFloat("YPos", position.y);
        PlayerPrefs.SetFloat("ZPos", position.z);
        PlayerPrefs.Save();
    }

    public void LoadDataEventHandler()
    {
        _healthController.SetCurrentHp(PlayerPrefs.GetInt("Health", 50));

        var position = new Vector3(PlayerPrefs.GetFloat("XPos"), PlayerPrefs.GetFloat("YPos"),
            PlayerPrefs.GetFloat("ZPos"));

        _rigidbody.position = position;
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("Health");
        PlayerPrefs.DeleteKey("XPos");
        PlayerPrefs.DeleteKey("YPos");
        PlayerPrefs.DeleteKey("ZPos");
    }
}