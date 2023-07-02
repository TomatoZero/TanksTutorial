using System;
using UnityEngine;

namespace TankTutorial.Scripts
{
    public static class JsonSerializer
    {
        public static void Save(string fileName, RoundSum sum)
        {
            var collection = Deserialize<Statistic>(fileName);
            
            collection.Add(sum);
            // else collection = new Statistic();

            // Debug.Log($"{String.Join(' ', collection._rounds)}");
            
            var json = Serialize(collection);
            SaveData(fileName, json);            
        }

        public static T Read<T>(string fileName)
        {
            return Deserialize<T>(fileName);
        }
        
        private static string Serialize(Statistic stat)
        {
            return JsonUtility.ToJson(stat);
        }

        private static T Deserialize<T>(string fileName)
        {
            var path = Application.streamingAssetsPath + $"/{fileName}.json";

            var json = System.IO.File.ReadAllText(path);

            return JsonUtility.FromJson<T>(json);
        }
        
        private static void SaveData(string fileName,string data)
        {
            System.IO.File.WriteAllText(Application.streamingAssetsPath + $"/{fileName}.json", data);
        }
    }
}