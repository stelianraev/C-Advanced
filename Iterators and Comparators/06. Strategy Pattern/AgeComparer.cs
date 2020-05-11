using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Strategy_Pattern
{
    public class AgeComparer : IComparer<Person>
    {
        public int Compare([AllowNull] Person x, [AllowNull] Person y)
        {
            int result = 1;

            if(y != null)
            {
                result = x.Age.CompareTo(y.Age);

                if(result == 0)
                {
                    result = x.Name.CompareTo(y.Name);
                }
            }
            return result;
        }
    }
}
