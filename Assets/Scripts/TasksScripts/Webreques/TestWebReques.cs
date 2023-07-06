using System;
using System.Collections.Generic;
using TankTutorial.Scripts.UI;
using UnityEngine;

namespace TankTutorial.Scripts.TaskScripts.Webrequest
{
    public class TestWebReques : MonoBehaviour
    {
        [SerializeField, TextArea] private string _url;
        [SerializeField] private List<RequestHeaderData> _request;
        [SerializeField] private StatsController _statsController;
        [SerializeField] private HttpClient _httpClient;

        private void Awake()
        {
            _httpClient.InsertData(_url, _request);
        }

        [ContextMenu("Test Get")]
        public void TestGet()
        {
            _httpClient.DataReceivedEvent += GetData;
            _httpClient.Get<Statistic>();
        }

        public void TestPost()
        {
            _httpClient.Post<Statistic>(_statsController.Stats);
        }

        private void GetData(string result)
        {
            var stats = JsonUtility.FromJson<Statistic>(result);
            _statsController.ShowStats(stats);
            _httpClient.DataReceivedEvent -= GetData;
        }
    }

    [Serializable]
    public struct RequestHeaderData
    {
        public string _name;
        [TextArea] public string _value;
    }
}