using System;
using System.Collections.Generic;
using System.Linq;

namespace Strategy_Pattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SortedSet<Person> sortedSetByName = new SortedSet<Person>(new NameComparator());
            SortedSet<Person> sortedSetByAge = new SortedSet<Person>(new AgeComparer());
            
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personArrg = Console.ReadLine()
                    .Split(" ")
                    .ToArray();

                string personName = personArrg[0];
                int personAge = int.Parse(personArrg[1]);

                Person person = new Person(personName, personAge);

                sortedSetByName.Add(person);
                sortedSetByAge.Add(person);
            }

            Console.WriteLine(String.Join(Environment.NewLine, sortedSetByName));
            Console.WriteLine(String.Join(Environment.NewLine, sortedSetByAge));
           
        }
    }
}
