
using System;
using System.Collections.Generic;
using System.Linq;

namespace MultidimensionalArrays
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Ranking();
        }

        // 01. Unique Usernames
        public static void UniqueUsernames()
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> uniqueNames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string names = Console.ReadLine();
                uniqueNames.Add(names);
            }

            Console.WriteLine(String.Join("\n", uniqueNames));
        }

        // 02. Sets of Elements
        public static void SetsOfElements()
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            HashSet<int> result = new HashSet<int>();

            for (int i = 0; i < numbers[0] + numbers[1]; i++)
            {
                var input = int.Parse(Console.ReadLine());

                if (i < numbers[0])
                {
                    firstSet.Add(input);
                }
                else
                {
                    secondSet.Add(input);
                }
            }

            foreach (var num in firstSet)
            {
                foreach (var item in secondSet)
                {
                    if (num == item)
                    {
                        result.Add(num);
                    }
                }
            }

            Console.WriteLine(String.Join(" ", result));
        }

        // 03. Periodic Table
        public static void PeriodicTable()
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> elements = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();


                for (int j = 0; j < input.Count(); j++)
                {
                    elements.Add(input[j]);
                }
            }

            Console.WriteLine(String.Join(" ", elements.OrderBy(x => x)));
        }

        // 04. Even Times
        public static void EvenTimes()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(num))
                {
                    numbers[num] = 1;
                }
                else
                {
                    numbers[num]++;
                }
            }

            var selected = numbers.Where(x => x.Value % 2 == 0).FirstOrDefault();

            Console.WriteLine(selected.Key);
        }

        // 05. Count Symbols
        public static void CountSymbols()
        {
            string text = Console.ReadLine();

            Dictionary<char, int> chars = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!chars.ContainsKey(text[i]))
                {
                    chars[text[i]] = 1;
                }
                else
                {
                    chars[text[i]]++;
                }
            }

            foreach (var item in chars.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }

        // 06. Wardrobe
        public static void Wardrobe()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string color = input[0];
                string[] clothes = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!wardobe.ContainsKey(color))
                {
                    wardobe[color] = new Dictionary<string, int>();

                    for (int j = 0; j < clothes.Length; j++)
                    {


                        if (!wardobe[color].ContainsKey(clothes[j]))
                        {
                            wardobe[color][clothes[j]] = 1;
                        }
                        else
                        {
                            wardobe[color][clothes[j]]++;
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < clothes.Length; j++)
                    {
                        if (!wardobe[color].ContainsKey(clothes[j]))
                        {
                            wardobe[color][clothes[j]] = 1;
                        }
                        else
                        {
                            wardobe[color][clothes[j]]++;
                        }
                    }
                }
            }

            string[] command = Console.ReadLine().Split(" ");
            string lookigKey = command[0];
            string lookingCloth = command[1];

            foreach (var cloth in wardobe)
            {
                Console.WriteLine($"{cloth.Key} clothes:");

                foreach (var item in cloth.Value)
                {
                    if (lookigKey == cloth.Key && lookingCloth == item.Key)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }

        // 07. *The V-Logger
        public static void TheLogger()
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> vlogers = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] commands = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (commands.Contains("joined"))
                {
                    if (!vlogers.ContainsKey(commands[0]))
                    {
                        vlogers[commands[0]] = new Dictionary<string, HashSet<string>>();
                        vlogers[commands[0]].Add("followers", new HashSet<string>());
                        vlogers[commands[0]].Add("following", new HashSet<string>());
                    }
                }
                else if (commands.Contains("followed"))
                {
                    if (vlogers.ContainsKey(commands[0]) && vlogers.ContainsKey(commands[2]))
                    {
                        if (commands[0] != commands[2])
                        {
                            vlogers[commands[2]]["followers"].Add(commands[0]);
                            vlogers[commands[0]]["following"].Add(commands[2]);
                        }
                    }
                }
            }

            int count = 0;
            Console.WriteLine($"The V-Logger has a total of {vlogers.Count()} vloggers in its logs.");

            foreach (var vloger in vlogers.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["following"].Count))
            {
                count++;
                if (count == 1)
                {
                    Console.WriteLine($"{count}. {vloger.Key} : {vloger.Value["followers"].Count} followers, {vloger.Value["following"].Count} following");

                    foreach (var item in vloger.Value["followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {item}");
                    }
                }
                else
                {
                    Console.WriteLine($"{count}. {vloger.Key} : {vloger.Value["followers"].Count} followers, {vloger.Value["following"].Count} following");
                }
            }
        }

        // 08. *Ranking
        public static void Ranking()
        {
            Dictionary<string, string> courses = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> students = new Dictionary<string, Dictionary<string, int>>();

            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] coursePss = input.Split(":", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (!courses.ContainsKey(coursePss[0]))
                {
                    courses[coursePss[0]] = coursePss[1];
                }
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] studentInfo = input.Split("=>", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string contest = studentInfo[0];
                string password = studentInfo[1];
                string username = studentInfo[2];
                int points = int.Parse(studentInfo[3]);

                if (courses.ContainsKey(contest))
                {
                    if (courses[contest].Contains(password))
                    {
                        if (!students.ContainsKey(username))
                        {
                            students[username] = new Dictionary<string, int>();
                            students[username].Add(contest, points);
                        }
                        else
                        {
                            if (students[username].ContainsKey(contest))
                            {
                                if (students[username][contest] < points)
                                {
                                    students[username][contest] = points;
                                }
                            }
                            else
                            {
                                students[username][contest] = points;
                            }
                        }
                    }
                }
            }
            int sum = 0;
            string name = " ";
            foreach (var student in students)
            {
                int temp = 0;

                foreach (var item in student.Value)
                {
                    var points = item.Value;
                    temp += points;

                    if(sum < temp)
                    {
                        name = student.Key;
                        sum = temp;
                    }
                }
            }

            Console.WriteLine($"Best candidate is {name} with total {sum} points.");
            Console.WriteLine("Ranking:");

            foreach (var student in students.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{student.Key}");

                foreach (var info in student.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {info.Key} -> {info.Value}");
                }
            }
        }
    }
}