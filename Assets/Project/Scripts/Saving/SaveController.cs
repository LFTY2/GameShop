using System;
using UnityEditor.Overlays;
using UnityEngine;

namespace Project
{
    //Asset Easy Save 3 do it much better, but I avoid using assets here
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
            return ConvertToData(jsonNotation, defaultValue);
        }

        public static void Save<T>(string fileName, T data)
        {
            string save = ConvertToJson(data);
            PlayerPrefs.SetString(fileName, save);
            PlayerPrefs.Save();
        }

        public static string ConvertToJson<T>(T data)
        {
            if (data == null)
            {
                return String.Empty;
            }
            string jsonNotation = JsonUtility.ToJson(data);
            SaveData saveData = new SaveData(data.GetType().AssemblyQualifiedName, jsonNotation);
            string save = JsonUtility.ToJson(saveData);
            return save;
        }

        public static T ConvertToData<T>(string json, T defaultValue)
        {
            if (json == String.Empty)
            {
                return defaultValue;
            }
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            object jsonObject = JsonUtility.FromJson(saveData.Json, Type.GetType(saveData.Type));
            return (T)jsonObject;
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