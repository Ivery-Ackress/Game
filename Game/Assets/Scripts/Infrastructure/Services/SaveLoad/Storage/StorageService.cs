using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public class StorageService : IStorageService
{
    public void Save<T>(string key, T data)
    {
        var path = BuildPath(key);
        var json = JsonConvert.SerializeObject(data);
        using (var fileStream = new StreamWriter(path))
            fileStream.Write(json);
    }

    public T Load<T>(string key)
    {
        var path = BuildPath(key);
        try
        {
            using (var fileStream = new StreamReader(path))
            {
                var json = fileStream.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
            return default(T);
        }
    }

    private string BuildPath(string key)
    {
        //persistentDataPath одинаков для всех систем
        return Path.Combine(Application.persistentDataPath, key);
    }
}
