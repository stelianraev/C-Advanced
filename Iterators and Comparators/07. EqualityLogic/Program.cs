using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EqualityLogic
{
   public class Program
    {
        public static void Main(string[] args)
        {
            SortedSet<Person> sortedPersons = new SortedSet<Person>();
            HashSet<Person> hashSetPersons = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personArrg = Console.ReadLine()
                    .Split(" ")
                    .ToArray();

                string name = personArrg[0];
                int age = int.Parse(personArrg[1]);

                Person person = new Person(name, age);

                sortedPersons.Add(person);
                hashSetPersons.Add(person);
            }

            Console.WriteLine(sortedPersons.Count);
            Console.WriteLine(hashSetPersons.Count);
        }
    }
}
