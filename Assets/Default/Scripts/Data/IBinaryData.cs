using UnityEngine;

namespace Default.Scripts.Data
{
    public abstract class IBinaryData
    {
        protected string _id;
        public abstract void Save();
        public abstract void Load();

        public string GetPath()
        {
            return Application.persistentDataPath + "/" + _id;
        }
    }
}
