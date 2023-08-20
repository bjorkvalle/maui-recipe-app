//using System.Text;

//namespace bjorkvalle.UI.Utilities
//{
//    public static class StringExtensions
//    {
//        public static string[] SplitIf(this string text, bool condition, char separator = ',')
//        {
//            if (condition)
//                return text.Split(separator);

//            return null;
//        }

//        public static StringBuilder AppendIf(this StringBuilder builder, bool condition, string toAppend)
//        {
//            if (condition)
//                builder.Append(toAppend);

//            return builder;
//        }

//        public static StringBuilder AppendIfElse(this StringBuilder builder, bool condition, string ifToAppend, string elseToAppend)
//        {
//            if (condition)
//                builder.Append(ifToAppend);
//            else
//                builder.Append(elseToAppend);

//            return builder;
//        }

//        /// <summary>
//        /// Concatenates two sequences if condition is met
//        /// </summary>
//        /// <param name="text"></param>
//        /// <param name="condition"></param>
//        /// <param name="toConcat"></param>
//        /// <returns>An System.Collections.Generic.IEnumerable`1 that contains the concatenated elements of the two input sequences.</returns>
//        public static IEnumerable<string> ConcatIf(this IEnumerable<string> text, bool condition, IEnumerable<string> toConcat)
//        {
//            if (condition)
//                return text.Concat(toConcat);

//            return text;
//        }

//        public static string JoinStringArray(this IEnumerable<string> arrayToJoin, char separator = ',')
//        {
//            if (arrayToJoin != null && arrayToJoin.Any())
//                return string.Join(separator, arrayToJoin);
//            else
//                return null;
//        }

//        public static string FirstCharToUpper(this string input) =>
//            input switch
//            {
//                null => throw new ArgumentNullException(nameof(input)),
//                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
//                _ => input.First().ToString().ToUpper() + input.Substring(1)
//            };

//        /// <summary>
//        /// e.g "this is an example" => "This Is An Example"
//        /// </summary>
//        /// <param name="input"></param>
//        /// <param name="separator"></param>
//        /// <returns></returns>
//        public static string CapitalizeWords(this string input, char separator = ' ') =>
//             input switch
//             {
//                 null => throw new ArgumentNullException(nameof(input)),
//                 "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
//                 _ => string.Join(separator, input
//                     .Split(separator)
//                     .Select(x => FirstCharToUpper(x)))
//             };

//        /// <summary>
//        /// Split input string by Capital letters
//        /// </summary>
//        /// <param name="input"></param>
//        /// <returns>CapitalCase -> [Camel,Case]</returns>
//        public static string[] SplitCamelCase(this string input)
//        {
//            return System.Text.RegularExpressions.Regex.Split(input, @"(?<!^)(?=[A-Z])");

//            //? space separated string, e.g TotalDigital -> Total Digital
//            //Console.WriteLine(System.Text.RegularExpressions.Regex.Replace(input, "([A-Z])", " $1", System.Text.RegularExpressions.RegexOptions.Compiled).Trim());
//        }
//    }
//}