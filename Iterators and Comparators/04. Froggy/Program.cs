using System;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Froggy
{
   public class Program
    {
       public static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            var input = Console.ReadLine()
                .Split(new char[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Lake lake = new Lake(input);

            Console.WriteLine(String.Join(", ", lake));
        }
    }
}
