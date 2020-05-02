using DefiningClasses;
using System;
using System.Linq;

namespace DefiningClasses
{
   public class StartUp
    {
       public static void Main(string[] args)
        {
            Family family = new Family();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Person person = new Person(input[0], int.Parse(input[1]));

                family.AddMember(person);
            }
            
            Console.WriteLine(family.GetOldestMember());
        }
    }
}
