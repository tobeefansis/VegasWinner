using UnityEngine;

namespace SaveLoadSystem
{
    public static class SaveSystem
    {
        public static void Save<T>(string key, T value)
        {
            var dataString = JsonUtility.ToJson(value);
            PlayerPrefs.SetString(key,dataString);
        }
    }
}
