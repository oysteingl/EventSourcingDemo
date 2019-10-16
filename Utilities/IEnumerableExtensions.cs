using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilities
{
    public static class IEnumerableExtensions
    {
        public static bool None<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return collection.All(p => predicate(p) == false);
        }
    }
}