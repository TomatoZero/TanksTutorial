using System;
using System.Collections.Generic;

namespace TankTutorial.TankTutorial
{
    [Serializable]
    public struct RoundSum
    {
        public int _firstTankWins;
        public int _secondTankWins;
        public int _rounds;
        public int _winner;
        public JsonDateTime _data;
        
        public void InsertValue(int firstTankWins, int secondTankWins)
        {
            _firstTankWins = firstTankWins;
            _secondTankWins = secondTankWins;
            _rounds = _firstTankWins + _secondTankWins;

            if (_firstTankWins > _secondTankWins) _winner = 1;
            else _winner = 2;

            _data = DateTime.Now;
        }
        
        public override string ToString()
        {
            return $"firstPlayer {_firstTankWins} secondPlayer {_secondTankWins}";
        }
    }

    public struct Statistic
    {
        public List<RoundSum> _rounds;

        public void Add(RoundSum round)
        {
            _rounds ??= new List<RoundSum>();

            _rounds.Add(round);
        }

        public void Remove(RoundSum round)
        {
            _rounds.Remove(round);
        }
    }

    [Serializable]
    public struct JsonDateTime
    {
        public long value;

        public static implicit operator DateTime(JsonDateTime jdt)
        {
            return DateTime.FromFileTimeUtc(jdt.value);
        }

        public static implicit operator JsonDateTime(DateTime dt)
        {
            JsonDateTime jdt = new JsonDateTime();
            jdt.value = dt.ToFileTimeUtc();
            return jdt;
        }

        public override string ToString()
        {
            return $"{(DateTime)this}";
        }
    }
}