using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int likeChosen = 0;
            int notLikeChosen = 0;

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var personArrgs = input
                    .Split(" ")
                    .ToArray();

                Person person = new Person(personArrgs[0], int.Parse(personArrgs[1]), personArrgs[2]);

                people.Add(person);
            }

            var command = int.Parse(Console.ReadLine());

            Person chosen = people[command - 1];

            foreach (var item in people)
            {
                if (item.CompareTo(chosen) == 0)
                {
                    likeChosen++;
                }
                else if (item.CompareTo(chosen) != 0)
                {
                    notLikeChosen++;
                }
            }

            if (likeChosen == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.Write($"{likeChosen} {notLikeChosen} {people.Count}");

            }
        }
    }
}
