using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;

namespace FunctionalCoding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
        }

        // 01. Action Point
        public static void ActionPoint()
        {
            Action<string> print = Console.WriteLine;

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(print);
        }

        // 02. Knights of Honor
        public static void KnightOfHonor()
        {
            Action<string> a = x => Console.WriteLine("Sir " + x);

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(a);


        }

        // 03. Custom Min Function
        public static void CustomMinFunc()
        {
            Func<int[], int> minFunc = x => x.Min();

            var nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(minFunc(nums));
        }

        // 04. Find Even or Odds
        public static void FindEvenOrOdds()
        {
            int[] bounds = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string query = Console.ReadLine();

            Predicate<int> predicate = query == "odd" ? new Predicate<int>((n) => n % 2 == 0) :
            new Predicate<int>((n) => n % 2 != 0);

            List<int> res = new List<int>();

            for (int i = bounds[0]; i <= bounds[1]; i++)
            {
                if (predicate(i))
                {
                    res.Add(i);
                }
            }

            Console.WriteLine(String.Join(" ", res));
        }

        // 05. Applied Arithmetics
        public static void AppliedArithmetics()
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "print")
                {
                    Console.WriteLine(String.Join(" ", numbers));
                }
                else
                {
                    Func<int[], int[]> process = GetProcessor(command);
                    numbers = process(numbers);
                }
            }

        }
        static Func<int[], int[]> GetProcessor(string command)
        {
            Func<int[], int[]> processor = null;

            if (command == "add")
            {
                processor = new Func<int[], int[]>((arr) =>
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] += 1;
                    }
                    return arr;
                });
            }
            else if (command == "multiply")
            {
                processor = new Func<int[], int[]>((arr) =>
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] *= 2;
                    }
                    return arr;
                });
            }
            else if (command == "subtract")
            {
                processor = new Func<int[], int[]>((arr) =>
               {
                   for (int i = 0; i < arr.Length; i++)
                   {
                       arr[i] -= 1;
                   }
                   return arr;
               });
            }

            return processor;
        }

        // 06. Reverse and Exclude       
        public static void ReverseAndExclude()
        {

            var numbers = Console.ReadLine()
             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToArray();

            int n = int.Parse(Console.ReadLine());

            // Checkign if num % n != 0;
            Func<int, bool> myFilter = ((num) =>
            {
                if (num % n != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });

            var nums = numbers
            .Where(myFilter)
            .ToArray();

            // Reversing the result array
            Func<int[], int[]> reverse = ((arr) =>
            {
                for (int i = 1; i <= arr.Length / 2; i++)
                {
                    int temp = arr[i - 1];
                    arr[i - 1] = arr[arr.Length - i];
                    arr[arr.Length - i] = temp;
                }
                return arr;
            });

            var result = reverse(nums);

            Console.WriteLine(String.Join(" ", result));

        }

        // 07. Predicate for Names()
        public static void PredicateForNames()
        {
            int n = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Func<string, bool> checkingNames = ((arr) =>
            {
                if (arr.Length > n)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            });

            names
           .Where(checkingNames)
           .ToList()
           .ForEach(Console.WriteLine);
        }

        // 08. Custom Comparator
        public static void CustomComparator()
        {
            Func<int, int, int> comparator = new Func<int, int, int>((a, b) =>
            {
                if (a % 2 == 0 && b % 2 != 0)
                {
                    return -1;
                }
                else if (a % 2 != 0 && b % 2 == 0)
                {
                    return 1;
                }
                else
                {
                    return a.CompareTo(b);
                }
            });

            Comparison<int> comparison = new Comparison<int>(comparator);

            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(numbers, comparison);

            Console.WriteLine(String.Join(" ", numbers));
        }

        // 09. List of Predicates
        public static void ListOfPredicates()
        {
            int n = int.Parse(Console.ReadLine());

            int[] devidibleNums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int[], int[]> num = ((arr, devidnum) =>
            {
                List<int> a = new List<int>();

                for (int i = 1; i <= arr; i++)
                {
                    bool isDev = true;
                    for (int j = 0; j < devidnum.Length; j++)
                    {
                        if (i % devidnum[j] != 0)
                        {
                            isDev = false;
                        }
                    }

                    if (isDev == true)
                    {
                        a.Add(i);
                    }

                }
                return a.ToArray();
            });

            var test = num(n, devidibleNums);
            Console.WriteLine(String.Join(" ", test));
        }

        // 10. Predicate Party
        public static void PredicateParty()
        {
            var guests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;
            while((command = Console.ReadLine()) != "Party!")
            {
                string[] cmdArgs = command
                    .Split(" ")
                    .ToArray();

                string cmdType = cmdArgs[0];
                string[] predicateArgs = cmdArgs
                    .Skip(1)
                    .ToArray();

                Predicate<string> predicate = GetPredicate(predicateArgs);

                if(cmdType == "Remove")
                {
                    guests.RemoveAll(predicate);
                }
                else if (cmdType == "Double")
                {
                    DoubleGuests(guests, predicate);
                }
            }

            if(guests.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine($"{String.Join(", ", guests)} are going to the party!");
            }

        }

        static void DoubleGuests(List<string> guests, Predicate<string> predicate)
        {
            for (int i = 0; i < guests.Count; i++)
            {
                string currGuest = guests[i];

                if (predicate(currGuest))
                {
                    guests.Insert(i + 1, currGuest);
                    i++;
                }
            }
        }

        static Predicate<string> GetPredicate(string[] predicateArgs)
        {
            string prType = predicateArgs[0];
            string prArgs = predicateArgs[1];

            Predicate<string> predicate = null;

            if(prType == "StartsWith")
            {
                predicate = new Predicate<string>((name) =>
                {
                    return name.StartsWith(prArgs);
                });
            }
            else if (prType == "EndsWith")
            {
                predicate = new Predicate<string>((name) =>
                {
                    return name.EndsWith(prArgs);
                });
            }
            else if(prType == "Length")
            {
                predicate = new Predicate<string>((name) =>
                {
                    return name.Length == int.Parse(prArgs);
                });
            }

            return predicate;
        }
       