using System;
using System.Text.RegularExpressions;

namespace NaturalComparer
{
    internal class ComparerHelpers
    {
        public static int CompareTo(string left, string right)
        {
            const string splitStringPattern = "[\\d*]";
            const string replaceAllButIntPattern = "\\D*";

            if (left == null && right == null)
                return 0;

            if (left == null)
                return -1;

            if (right == null)
                return 1;

            if (left == right)
                return 0;

            var comp = String.Compare(Regex.Split(left, splitStringPattern)[0],
                                      Regex.Split(right, splitStringPattern)[0],
                                      StringComparison.OrdinalIgnoreCase);
            if (comp != 0)
                return comp;

            Int32 leftNumber;
            Int32 rightNumber;
            Int32.TryParse(Regex.Replace(left, replaceAllButIntPattern, String.Empty), out leftNumber);
            Int32.TryParse(Regex.Replace(right, replaceAllButIntPattern, String.Empty), out rightNumber);

            return leftNumber.CompareTo(rightNumber);
        }
    }
}
