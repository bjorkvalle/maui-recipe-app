namespace bjorkvalle.infrastructure.Utilities
{
    /// <summary>
    /// Class Mapper
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TTarget"></typeparam>
    public class Mapper<TSource, TTarget>
        where TSource : class
        where TTarget : new()
    {
        public TTarget Map(TSource source)
        {
            TTarget destination = new TTarget();

            // Get all properties of the SourceClass
            var sourceProperties = typeof(TTarget).GetProperties();

            // Get all properties of the DestinationClass
            var destinationProperties = typeof(TSource).GetProperties();

            // Map properties from source to destination
            foreach (var destinationProp in destinationProperties)
            {
                var sourceProp = sourceProperties.FirstOrDefault(
                    p => p.Name == destinationProp.Name
                );

                if (sourceProp != null && sourceProp.PropertyType == destinationProp.PropertyType)
                {
                    var value = sourceProp.GetValue(source);
                    destinationProp.SetValue(destination, value);
                }
            }

            return destination;
        }

        public List<TTarget> Map(List<TSource> sourceList)
        {
            List<TTarget> destinationList = new List<TTarget>();

            foreach (var source in sourceList)
            {
                TTarget destination = Map(source);
                destinationList.Add(destination);
            }

            return destinationList;
        }
    }
}
