namespace bjorkvalle.infrastructure.Extensions
{
    public static class CopyExtensions
    {
        public static string Serialize<T>(this T item)
        {
            var serialized = JsonSerializer.Serialize(item);
            return serialized;
        }

        public static T Deserialize<T>(this string item, JsonSerializerOptions options = null)
        {
            var deserialized = JsonSerializer.Deserialize<T>(item, options);
            return deserialized;
        }
    }
}
