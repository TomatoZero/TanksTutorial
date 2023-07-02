 using System;
using System.Collections.Generic;
using TankTutorial.Scripts;
 using TankTutorial.Scripts.UI;
 using UnityEngine;

public class TestWebReques : MonoBehaviour
{
    [SerializeField, TextArea] private string _url;
    [SerializeField] private List<RequestHeaderData> _request;
    [SerializeField] private StatsController _statsController;

    [ContextMenu("Test Get")]
    public async void TestGet()
    {
        var client = new HttpClient(_url, _request);
        var result = await client.Get<Statistic>();
        _statsController.ShowStats(result);
    }
}

[Serializable]
public struct RequestHeaderData
{
    public string _name;
    [TextArea] public string _value;
}