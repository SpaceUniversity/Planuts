using System.IO;
using System.Text;
using UnityEngine;

namespace Default.Scripts.Data
{
    public class BinaryData<T> : IBinaryData where T : class
    {
        private T _value;
        BinaryData(T value, string id)
        {
            _value = value;
            _id = id;
        }
        T Get()
        {
            return _value;
        }

        void Set(T value)
        {
            _value = value;
        }
        public override async void Save()
        {
            var jsonString = JsonUtility.ToJson(_value, true);
            using FileStream fileStream = File.Open(GetPath(), FileMode.Create); // 5
            using BinaryWriter binaryWriter = new(fileStream, Encoding.UTF8); // 6
            binaryWriter.Write(jsonString);
#if UNITY_EDITOR
            UnityEngine.Debug.Log(_id + " is saved!");
            UnityEngine.Debug.Log(GetPath());
#endif
        }
        public override async void Load()
        {
            if (File.Exists(GetPath())) // 9
            {
                using FileStream fileStream = File.Open(GetPath(), FileMode.Open);
                using BinaryReader binaryReader = new(fileStream);
                var jsonString = binaryReader.ReadString();
                _value = JsonUtility.FromJson<T>(jsonString);
#if UNITY_EDITOR
                UnityEngine.Debug.Log(_id + " is loaded!");
                UnityEngine.Debug.Log(GetPath());
#endif
            }
        }
    }
}