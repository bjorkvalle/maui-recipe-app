namespace bjorkvalle.infrastructure.Extensions
{
    public static class DictionaryExtensions
    {
        public static IEnumerable<KeyValuePair<TKey, TValue>> TakeLastIf<TKey, TValue>(this IDictionary<TKey, TValue> dic, bool condition, int take)
        {
            if (condition)
                return dic.TakeLast(take);

            return dic;
        }

        public static void AddRangeOverride<TKey, TValue>(this IDictionary<TKey, TValue> dic, IDictionary<TKey, TValue> dicToAdd)
        {
            dicToAdd.ForEach(x => dic[x.Key] = x.Value);
        }

        public static void AddRangeNewOnly<TKey, TValue>(this IDictionary<TKey, TValue> dic, IDictionary<TKey, TValue> dicToAdd)
        {
            dicToAdd.ForEach(x => { if (!dic.ContainsKey(x.Key)) dic.Add(x.Key, x.Value); });
        }

        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dic, IDictionary<TKey, TValue> dicToAdd)
        {
            dicToAdd.ForEach(x => dic.Add(x.Key, x.Value));
        }

        public static bool ContainsKeys<TKey, TValue>(this IDictionary<TKey, TValue> dic, IEnumerable<TKey> keys)
        {
            bool result = false;
            keys.ForEachOrBreak((x) => { result = dic.ContainsKey(x); return result; });
            return result;
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }

        public static void ForEachOrBreak<T>(this IEnumerable<T> source, Func<T, bool> func)
        {
            foreach (var item in source)
            {
                bool result = func(item);
                if (result) break;
            }
        }

        public static bool IsDifferent<TKey, TValue>(this IDictionary<TKey, TValue> dic, IDictionary<TKey, TValue> dicToCompare)
        {
            if (dicToCompare == null)
                return true;

            return dic.Count == dicToCompare.Count && !dic.Except(dicToCompare).Any();
        }

        public static bool IsNullOrEmpty<TKey, TValue>(this IDictionary<TKey, TValue> dic)
        {
            if (dic == null || !dic.Any())
                return true;

            return false;
        }

        public static TValue ValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            return dictionary.TryGetValue(key, out TValue value) ? value : defaultValue;
        }
    }
}
