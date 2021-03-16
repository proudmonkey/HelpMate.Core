using System.Collections.Generic;
using System.Linq;

namespace HelpMate.Core.Extensions
{
    public static class NullHandlingValidationExtension
    {
        public static IEnumerable<T> AsNotNull<T>(this IEnumerable<T> source)
            => source ?? Enumerable.Empty<T>();

        public static bool IsNotNull<T>(this IEnumerable<T> source)
            => !(source is null);

        public static bool IsNotNull<T>(this T source)
           => !(source is null);

        public static bool IsNull<T>(this IEnumerable<T> source)
           => (source is null);

        public static bool IsNull<T>(this T source)
           => (source is null);
    }
}
