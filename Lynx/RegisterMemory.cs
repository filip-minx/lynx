using System;
using System.Collections;
using System.Collections.Generic;

namespace Lynx
{
    public class RegisterMemory : IDictionary<object, object>
    {
        private Dictionary<object, object> data = new Dictionary<object, object>();

        public T GetValueAs<T>(object key)
        {
            return (T)Convert.ChangeType(data[key], typeof(T));
        }

        public bool TryGetValueAs<T>(object key, out T value)
        {
            if (!data.TryGetValue(key, out var valueObject))
            {
                value = default;
                return false;
            }

            value = (T)Convert.ChangeType(valueObject, typeof(T));
            return true;
        }

        public object this[object key] { get => ((IDictionary<object, object>)data)[key]; set => ((IDictionary<object, object>)data)[key] = value; }

        public ICollection<object> Keys => ((IDictionary<object, object>)data).Keys;

        public ICollection<object> Values => ((IDictionary<object, object>)data).Values;

        public int Count => ((IDictionary<object, object>)data).Count;

        public bool IsReadOnly => ((IDictionary<object, object>)data).IsReadOnly;

        public void Add(object key, object value)
        {
            ((IDictionary<object, object>)data).Add(key, value);
        }

        public void Add(KeyValuePair<object, object> item)
        {
            ((IDictionary<object, object>)data).Add(item);
        }

        public void Clear()
        {
            ((IDictionary<object, object>)data).Clear();
        }

        public bool Contains(KeyValuePair<object, object> item)
        {
            return ((IDictionary<object, object>)data).Contains(item);
        }

        public bool ContainsKey(object key)
        {
            return ((IDictionary<object, object>)data).ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<object, object>[] array, int arrayIndex)
        {
            ((IDictionary<object, object>)data).CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<object, object>> GetEnumerator()
        {
            return ((IDictionary<object, object>)data).GetEnumerator();
        }

        public bool Remove(object key)
        {
            return ((IDictionary<object, object>)data).Remove(key);
        }

        public bool Remove(KeyValuePair<object, object> item)
        {
            return ((IDictionary<object, object>)data).Remove(item);
        }

        public bool TryGetValue(object key, out object value)
        {
            return ((IDictionary<object, object>)data).TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IDictionary<object, object>)data).GetEnumerator();
        }
    }
}
