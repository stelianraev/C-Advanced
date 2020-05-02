using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DefiningClasses
{
   public class StartUp
    {
       public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Person person = new Person(input[0], int.Parse(input[1]));

                people.Add(person);
            }

            foreach (var person in people.Where(x => x.Age > 30).OrderBy(x => x.Name))
            {
                Console.WriteLine(person);
            }
        }
    }
}
