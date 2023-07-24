namespace bjorkvalle.infrastructure.Extensions
{
    public static class ListExtensions
    {
        public static void AddRangeIfAny<T>(this List<T> list, IEnumerable<T> toAdd)
        {
            list.AddRangeIf(!toAdd.IsNullOrEmpty(), toAdd);
        }

        public static void AddIfAny<T>(this List<T> list, T toAdd)
        {
            list.AddIf(toAdd != null, toAdd);
        }

        public static void AddRangeIf<T>(this List<T> list, bool condition, IEnumerable<T> toAdd)
        {
            if (condition)
                list.AddRange(toAdd);
        }

        public static void AddIf<T>(this List<T> list, bool condition, T toAdd)
        {
            if (condition)
                list.Add(toAdd);
        }

        public static IEnumerable<T> ConcatIf<T>(this IEnumerable<T> list, bool condition, IEnumerable<T> toConcat)
        {
            if (condition)
                return list.Concat(toConcat);

            return list;
        }

        public static IEnumerable<T> ConcatIf<T>(this IEnumerable<T> list, bool condition, T toConcat)
        {
            if (condition)
                list = list.Concat(toConcat);

            return list;
        }

        public static IEnumerable<T> ConcatParams<T>(this IEnumerable<T> list, params T[] toConcat)
        {
            foreach (var item in toConcat)
                list = list.Concat(item);

            return list;
        }

        public static IEnumerable<T> Concat<T>(this IEnumerable<T> seq, T item)
        {
            foreach (var i in seq)
            {
                yield return i;
            }
            yield return item;
        }

        public static IEnumerable<T> ConcatIfAny<T>(this IEnumerable<T> list, IEnumerable<T> toConcat)
        {
            return list.ConcatIf(!toConcat.IsNullOrEmpty(), toConcat);
        }

        public static T[] ConcatIf<T>(this T[] list, bool condition, T[] toConcat)
        {
            if (condition)
                return list.Concat(toConcat).ToArray();

            return list;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
        {
            if (list == null || !list.Any())
                return true;

            return false;
        }

        public static IEnumerable<T> TakeIf<T>(this IEnumerable<T> list, bool condition, int? count)
        {
            if (condition && count.HasValue)
                return list.Take(count.Value);

            return list;
        }

        public static IEnumerable<T> ForEachList<T>(this IEnumerable<T> list, Action<T> action)
        {
            list.ToList().ForEach(action);
            return list;
        }

        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> list, bool condition, Func<T, bool> func)
        {
            if (condition)
                return list.Where(func);

            return list;
        }

        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> list, string sortby, bool? isAscending = true)
        {
            var asc = isAscending ?? true;
            var orderFlag = System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance;
            Func<T, object> func = x => x.GetType().GetProperty(sortby, bindingAttr: orderFlag).GetValue(x, null);

            return asc
                ? list.OrderBy(func)
                : list.OrderByDescending(func);
        }

        public static IEnumerable<T> OrderByIf<T>(this IEnumerable<T> list, bool condition, Func<T, object> func, bool? isAscending = true)
        {
            var asc = isAscending ?? true;

            if (condition)
            {
                if (asc)
                    return list.OrderBy(func);
                else
                    return list.OrderByDescending(func);
            }

            return list;
        }

        public static IEnumerable<T> OrderByIf<T>(this IEnumerable<T> list, bool condition, string sortby, bool? isAscending = true)
        {
            var asc = isAscending ?? true;
            var orderFlag = System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance;
            Func<T, object> func = x => x.GetType().GetProperty(sortby, bindingAttr: orderFlag).GetValue(x, null);

            if (condition)
            {
                if (asc)
                    return list.OrderBy(func);
                else
                    return list.OrderByDescending(func);
            }

            return list;
        }

        public static IEnumerable<T> SkipIf<T>(this IEnumerable<T> list, bool condition, int toSkip)
        {
            if (condition)
                return list.Skip(toSkip);

            return list;
        }
    }
}
