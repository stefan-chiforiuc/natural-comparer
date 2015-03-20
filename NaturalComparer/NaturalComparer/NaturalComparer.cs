using System;
using System.Collections.Generic;

namespace NaturalComparer
{
    public class NaturalComparer : IComparer<string>
    {
        public virtual int Compare(string x, string y)
        {
            return ComparerHelpers.CompareTo(x, y);
        }
    }

    public class NaturalComparer<T> : IComparer<T> where T : class
    {
        private readonly string _argumentErrorMessage =
            "Given type T (" + typeof(T) + ") is not a " + typeof(string) + " or " +
            typeof(ExampleClass);

        public int Compare(T left, T right)
        {
            Func<T, string> getItem;
            AcceptedComparerData.TryGetValue(typeof(T), out getItem);

            if (getItem == null)
            {
                throw new ArgumentException(_argumentErrorMessage);
            }

            return new NaturalComparer().Compare(getItem(left), getItem(right));
        }

        private static readonly Dictionary<Type, Func<T, string>> AcceptedComparerData = new Dictionary
            <Type, Func<T, string>>
        {
            {
                typeof (string),
                arg => arg as string
            },
            {
                typeof (ExampleClass),
                arg => arg == null ? null : (arg as ExampleClass).Name
            }
        };
    }
}
