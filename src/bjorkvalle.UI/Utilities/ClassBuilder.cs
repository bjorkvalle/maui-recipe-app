using System.Text;

namespace bjorkvalle.UI.Utilities
{
    public interface IClassBuilder
    {
        ClassBuilder Begin(string value);
        ClassBuilder Begin(string value, bool condition);
        ClassBuilder Begin(string prefix, string value);
        ClassBuilder Begin(string prefix, string value, bool condition);
        ClassBuilder AddClass(string value);
        ClassBuilder AddClass(string value, bool condition);
        ClassBuilder AddClass(string prefix, string value);
        ClassBuilder AddClass(string prefix, string value, bool condition);
        ClassBuilder AddClass(IEnumerable<string> values);
        ClassBuilder AddClassFromAttributes(IReadOnlyDictionary<string, object> additionalAttributes);
        string GetClass();
    }

    public class ClassBuilder : IClassBuilder
    {
        private const char delimiter = ' ';
        private StringBuilder builder;

        public ClassBuilder Begin(string value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            builder = new StringBuilder(value).Append(delimiter);

            return this;
        }

        public ClassBuilder Begin(string value, bool condition)
        {
            if (!condition)
            {
                builder = new StringBuilder();
                return this;
            }

            if (value == null)
                throw new ArgumentNullException("value");

            builder = new StringBuilder(value).Append(delimiter);

            return this;
        }

        public ClassBuilder Begin(string prefix, string value)
        {
            if (prefix == null || value == null)
                throw new ArgumentNullException("prefix || value");

            builder = new StringBuilder(prefix).Append(value).Append(delimiter);

            return this;
        }

        public ClassBuilder Begin(string prefix, string value, bool condition)
        {
            if (!condition)
            {
                builder = new StringBuilder();
                return this;
            }

            if (prefix == null || value == null)
                throw new ArgumentNullException("prefix || value");

            builder = new StringBuilder(prefix).Append(value).Append(delimiter);

            return this;
        }

        public ClassBuilder AddClass(string value)
        {
            if (!string.IsNullOrEmpty(value))
                builder.Append(value).Append(delimiter);

            return this;
        }

        public ClassBuilder AddClass(string value, bool condition)
        {
            if (condition && !string.IsNullOrEmpty(value))
                builder.Append(value).Append(delimiter);

            return this;
        }

        public ClassBuilder AddClass(string prefix, string value)
        {
            if (!string.IsNullOrEmpty(value))
                builder.Append(prefix).Append(value).Append(delimiter);

            return this;
        }

        public ClassBuilder AddClass(string prefix, string value, bool condition)
        {
            if (condition && !string.IsNullOrEmpty(value))
                builder.Append(prefix).Append(value).Append(delimiter);

            return this;
        }

        public ClassBuilder AddClass(IEnumerable<string> values)
        {
            if (values.Any())
                builder.Append(string.Join(delimiter.ToString(), values)).Append(delimiter);

            return this;
        }

        public ClassBuilder AddClassFromAttributes(IReadOnlyDictionary<string, object> additionalAttributes)
        {
            if (builder is null)
                builder = new StringBuilder();

            // https://stackoverflow.com/questions/70885840/blazor-attribute-splatting-issues-with-cssbuilder-package

            var classAttributes = additionalAttributes?.GetValueOrDefault("class", null);

            if (classAttributes != null)
                builder.Append(classAttributes);

            return this;
        }

        public string GetClass() => builder?.ToString().TrimEnd();
    }
}
