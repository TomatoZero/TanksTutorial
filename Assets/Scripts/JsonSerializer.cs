using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TankTutorial.Scripts
{
    public static class JsonSerializer
    {
        public static void Save(string fileName, RoundSum sum)
        {
            TryCreate(fileName);
            var collection = Deserialize<Statistic>(fileName);

            collection.Add(sum);

            var json = Serialize(collection);
            SaveData(fileName, json);
        }

        public static T Read<T>(string fileName)
        {
            TryCreate(fileName);
            return Deserialize<T>(fileName);
        }

        private static string Serialize(Statistic stat)
        {
            return JsonUtility.ToJson(stat);
        }

        private static T Deserialize<T>(string fileName)
        {
            var path = Application.persistentDataPath + $"/{fileName}.json";
            var json = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(json);
        }

        private static void TryCreate(string fileName)
        {
            var path = Application.persistentDataPath + $"/{fileName}.json";
            if (!File.Exists(path))
            {
                using var fileStream = File.Create(path);
                AddText(fileStream, "{}");
            }
        }

        private static Task AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
            return Task.CompletedTask;
        }

        private static void SaveData(string fileName, string data)
        {
            var path = Application.persistentDataPath + $"/{fileName}.json";
            if (!File.Exists(path)) File.Create(path);
            File.WriteAllText(Application.persistentDataPath + $"/{fileName}.json", data);
        }
    }
}