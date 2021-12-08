using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.MembersRegistration.Infrastructure.Extensions
{
    internal static class EnumerableExtensions
    {
        public static TItem FirstOrDefault<TItem, TSource>(this IEnumerable<TSource> items)
            where TItem : class
           => items.FirstOrDefault<TItem>();

        public static TItem FirstOrDefault<TItem>(this IEnumerable items)
            where TItem : class
           => items.OfType<TItem>()
                .FirstOrDefault();
    }
}