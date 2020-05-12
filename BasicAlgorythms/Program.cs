using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ReverseArray
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SumOfCoins();
        }

        // 01. Reverse Array
        public static void ReverseArray()
        {
            int[] numbers = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            ReverseArrayRecursion(numbers, numbers.Length - 1);
        }

        public static void ReverseArrayRecursion(int[] numbers, int index)
        {
            if (index < 0)
            {
                return;
            }
            Console.Write(numbers[index] + " ");
            ReverseArrayRecursion(numbers, index - 1);
        }

        // 02. Nested Loops To Recursion
        private static int[] arr;
        public static void NestedLoopsToRecursion()
        {

            int n = int.Parse(Console.ReadLine());
            arr = new int[n];

            NestedLoop(n, 0);
        }
        public static void NestedLoop(int n, int counter)
        {
            if (counter >= n)
            {
                Console.WriteLine(String.Join(" ", arr));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                arr[counter] = i;
                NestedLoop(n, counter + 1);
            }
        }

        // 03. Connected Areas in a Matrix

        public static int rows;
        public static int cols;
        public struct Area
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public int Size { get; set; }
        }
        public static void ConnectedAreasinsMatrix()
        {
            rows = int.Parse(Console.ReadLine());
            cols = int.Parse(Console.ReadLine());

            char[][] matrix = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }

            List<Area> areas = new List<Area>();

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (char.IsDigit(matrix[r][c]))
                    {
                        Area area = new Area();

                        area.Row = r;
                        area.Col = c;
                        int size = 0;
                        FindAreaSize(matrix, r, c, ref size);
                        area.Size = size;
                        areas.Add(area);
                    }
                }
            }
            Console.WriteLine($"Total areas found: {areas.Count}");
            int counter = 1;
            foreach (var area in areas.OrderByDescending(a => a.Size).ThenBy(a => a.Row).ThenBy(a => a.Col))
            {
                Console.WriteLine($"Area #{counter++} at ({area.Row}, {area.Col}), size:" +
                    $"{area.Size}");
            }
        }

        private static void FindAreaSize(char[][] matrix, int r, int c, ref int size)
        {
            if (!IsInBounds(r, c) || matrix[r][c] == '*'
                || matrix[r][c] == 'X')
            {
                return;
            }

            size++;
            matrix[r][c] = 'X';

            FindAreaSize(matrix, r + 1, c, ref size);
            FindAreaSize(matrix, r, c + 1, ref size);
            FindAreaSize(matrix, r - 1, c, ref size);
            FindAreaSize(matrix, r, c - 1, ref size);
        }

        private static bool IsInBounds(int r, int c)
        {
            return r < rows && r >= 0 && c < cols && c >= 0;
        }

        // 04. Recursive Factorial
        public static void RecursiveFactoriel()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Factoriel(n));
        }

        public static int Factoriel(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            else
            {
                return n * Factoriel(n - 1);
            }
        }

        // 05. Sum of Coins
        public static void SumOfCoins()
        {
            var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
            var targetSum = 923;

            try
            {
                var selectedCoins = ChooseCoins(availableCoins, targetSum);

                Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
                foreach (var selectedCoin in selectedCoins)
                {
                    Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            var sortedCoins = coins
                .OrderByDescending(c => c)
                .ToList();

            var chosenCoins = new Dictionary<int, int>();
            int currentSum = 0;
            int coinIndex = 0;

            while (currentSum != targetSum && coinIndex < sortedCoins.Count)
            {
                int currentCoinValue = sortedCoins[coinIndex];
                int remainingSum = targetSum - currentSum;
                int numberOfCoinToTake = remainingSum / currentCoinValue;

                if (numberOfCoinToTake > 0)
                {
                    chosenCoins[currentCoinValue] = numberOfCoinToTake;

                    currentSum += currentCoinValue * numberOfCoinToTake;
                }

                coinIndex++;

            }

            if (currentSum == targetSum)
            {
                return chosenCoins;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
