using UnityEngine;

namespace SaveLoadSystem
{
    public static class LoadSystem
    {
        public static T LoadValue<T>(string key)
        {
            var dataString =   PlayerPrefs.GetString(key);
            return JsonUtility.FromJson<T>(dataString);
        }
    }
}
