using System;
using UnityEditor.Overlays;
using UnityEngine;

namespace Project
{
    public static class SaveController
    {
        public static bool HasKey(string key)
        {
            return PlayerPrefs.HasKey(key);
        }
        
        public static T Load<T>(string fileName, T defaultValue)
        {
            
            if (!PlayerPrefs.HasKey(fileName))
            {
                return defaultValue;
            }
            string jsonNotation = PlayerPrefs.GetString(fileName, String.Empty);
            SaveData saveData = JsonUtility.FromJson<SaveData>(jsonNotation);
            object jsonObject = JsonUtility.FromJson(saveData.Json, Type.GetType(saveData.Type));
            return (T)jsonObject;
        }

        public static void Save<T>(string fileName, T data)
        {
            string jsonNotation = JsonUtility.ToJson(data);
            SaveData saveData = new SaveData(data.GetType().AssemblyQualifiedName, jsonNotation);
            string save = JsonUtility.ToJson(saveData);
            PlayerPrefs.SetString(fileName, save);
            PlayerPrefs.Save();
        }
        
        public static void DeleteKey(string fileName)
        {
            PlayerPrefs.DeleteKey(fileName);
        }
    }
    [Serializable]
    public class SaveData
    {
        public string Type;
        public string Json;

        public SaveData(string type, string json)
        {
            Type = type;
            Json = json;
        }
    }

}