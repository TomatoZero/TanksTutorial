namespace TankTutorial.Scripts.UI
{
    public interface IRoundStats
    {
        public void Insert(string winner, string firstPlayerScore, string secondPlayerScore, string date);
        public void Destroy();
    }
}