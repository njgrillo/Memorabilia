using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Demo.Framework.Extension
{
    public static class CollectionExtensions
    {
        [DebuggerStepThrough]
        [DebuggerHidden]
        [ContractAnnotation("null => true; notnull => false")]
        public static bool IsNullOrEmptyCollection<T>([CanBeNull] this T collection) where T : IEnumerable
        {
            return collection == null || !collection.Cast<object>().Any();
        }

        [DebuggerStepThrough]
        [DebuggerHidden]
        public static void ForEach<T>([CanBeNull] this IEnumerable<T> enumerable, [NotNull] Action<T> action)
        {
            if (enumerable == null || !enumerable.Any())
                return;

            foreach (var item in enumerable.ToList())
            {
                action(item);
            }
        }

        [DebuggerStepThrough]
        [DebuggerHidden]
        public static void ForEach([CanBeNull] this IDictionary dictionary, [NotNull] Action<DictionaryEntry> action)
        {
            if (dictionary == null)
                return;

            foreach (var item in dictionary.Cast<DictionaryEntry>())
            {
                action(item);
            }
        }

        [DebuggerStepThrough]
        [DebuggerHidden]
        public static void ForEach<TKey, TValue>([CanBeNull] this IDictionary<TKey, TValue> dictionary, [NotNull] Action<TKey, TValue> action)
        {
            if (dictionary == null)
                return;

            foreach (var kvp in dictionary)
            {
                action(kvp.Key, kvp.Value);
            }
        }


    }
}
