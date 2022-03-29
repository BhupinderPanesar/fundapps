using System;
using System.Collections.Generic;
using System.Linq;

namespace BucketNetting.Tests
{
    internal static class EnumerableExtensions
    {
        public static T Second<T>(this IEnumerable<T> collection)
        {
            return collection.Skip(1).FirstOrDefault();
        }
        public static T Second<T>(this IEnumerable<T> collection, Func<T, bool> filter)
        {
            return collection.Skip(1).FirstOrDefault(filter);
        }
        public static T Third<T>(this IEnumerable<T> collection)
        {
            return collection.Skip(2).FirstOrDefault();
        }
        public static T Third<T>(this IEnumerable<T> collection, Func<T, bool> filter)
        {
            return collection.Skip(2).FirstOrDefault(filter);
        }
    }

}
