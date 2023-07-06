using UnityEngine;

namespace TankTutorial.Scripts.UI
{
    public class StatsController : MonoBehaviour
    {
        [SerializeField] private GameObject _statsPrefab;
        [SerializeField] private Transform _content;

        public delegate void DestroyChildren();

        public event DestroyChildren destroyChildrenEvent;

        public Statistic Stats => _stats;

        private Statistic _stats;

        public void ShowStats(string fileName)
        {
            SetActive(true);
            ClearList();
            ReadStats(fileName);
            InsertStats();
        }

        public void ShowStats(Statistic statistic)
        {
            SetActive(true);
            ClearList();
            _stats = statistic;
            InsertStats();
        }

        public void HideStats()
        {
            SetActive(false);
        }

        private void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        private void Add(RoundSum round)
        {
            var roundStats = Instantiate(_statsPrefab, _content).GetComponent<IRoundStats>();
            roundStats.Insert(round._winner.ToString(), round._firstTankWins.ToString(),
                round._secondTankWins.ToString(), round._data.ToString());
            destroyChildrenEvent += roundStats.Destroy;
        }

        private void ReadStats(string fileName)
        {
            _stats = JsonSerializer.Read<Statistic>(fileName);
        }

        private void ClearList()
        {
            if (destroyChildrenEvent != null)
            {
                destroyChildrenEvent.Invoke();
                ClearSubscribers();
            }
        }

        private void ClearSubscribers()
        {
            var subscribers = destroyChildrenEvent?.GetInvocationList();

            if (subscribers != null)
                foreach (var subscriber in subscribers)
                {
                    destroyChildrenEvent -= (DestroyChildren)subscriber;
                }
        }

        private void InsertStats()
        {
            foreach (var round in _stats._rounds)
            {
                Add(round);
            }
        }
    }
}