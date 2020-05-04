using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    class DateModifier
    {
        public void Difference(string date1, string date2)
        {
            var date1Arrgs = date1.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var date2Arrgs = date2.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            DateTime first = new DateTime(int.Parse(date1Arrgs[0]), int.Parse(date1Arrgs[1]), int.Parse(date1Arrgs[2]));
            DateTime second = new DateTime(int.Parse(date2Arrgs[0]), int.Parse(date2Arrgs[1]), int.Parse(date2Arrgs[2]));

            var diff = Math.Abs((first - second).Days);

            Console.WriteLine(diff);
        }
    }
}
