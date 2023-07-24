namespace bjorkvalle.infrastructure.Utilities
{
    public class ItemsCache : Dictionary<string, CacheModel>
    {
        public void SetDirty(string key)
        {
            if (TryGetValue(key, out CacheModel model))
            {
                model.IsDirty = true;
            }
        }
    }

    public static class ItemsCacheKeys
    {
        //public const string Projects = nameof(Projects);
    }

    public class CacheModel
    {
        public bool IsDirty { get; set; }
        public object Value { get; set; }
    }
}
