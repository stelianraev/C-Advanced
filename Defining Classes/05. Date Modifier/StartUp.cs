using DefiningClasses;
using System;

namespace ConsoleApp1
{
   public class StartUp
    {
       public static void Main(string[] args)
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();

            DateModifier datediff = new DateModifier();

            datediff.Difference(date1, date2);
        }
    }
}
