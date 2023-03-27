using UnityEngine;

namespace DLBASE
{
    public class DLOpition<T>where T:new ()
    {
        private T target;
        private string _key = "__";

        public void SetDirty(bool dirty)
        {
            if (dirty)
            {
                string str = JsonUtility.ToJson(data);
                PlayerPrefs.SetString(_key+data.GetType(),str);
            }
        }

        public T data
        {
            get
            {
                string str = PlayerPrefs.GetString(_key + data.GetType());
                return JsonUtility.FromJson<T>(str);
            }
            set
            {
                target = value;
                SetDirty(true);
            }
        }
    }
}