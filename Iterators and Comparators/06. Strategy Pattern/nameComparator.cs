using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Strategy_Pattern
{
    class NameComparator : IComparer<Person>
    {
        public int Compare([AllowNull] Person x, [AllowNull] Person y)
        {
            int result = x.Name.Length.CompareTo(y.Name.Length);
            if (result == 0)
            {
                result = x.Name.ToLower()[0].CompareTo(y.Name.ToLower()[0]);
            }

            return result;
        }
    }
}

