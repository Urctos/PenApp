using Newtonsoft.Json;

namespace PenApp.Entities.Extensions;

public static  class EntityExtensions
{
    public static void SaveToJson<T>(this IEnumerable<T> data,  string filePath) where T : class, IEntity
    {
        string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);
    }

    public static IEnumerable<T> LoadFromJson<T>( this string fileName) where T : class, IEntity
    {
        if (File.Exists(fileName))
        {
            string json = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
        }
        else
        {
            Console.WriteLine($"Plik {fileName} nie istnieje.");
            return Enumerable.Empty<T>();
        }
    }
}

