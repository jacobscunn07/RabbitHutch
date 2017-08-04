using System.Collections.Generic;

namespace RabbitHutch.Application.Helpers
{
    public static class DictionaryExtensions
    {
        public static TValue GetValueByKey<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
        {
            dict.TryGetValue(key, out TValue val);
            return val;
        }
    }
}
