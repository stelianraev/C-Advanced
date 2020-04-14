using System;
using System.Collections.Generic;
using System.Linq;

namespace MultidimensionalArrays
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
        }

        // 01. Diagonal Difference
        public static void DiagonalDifference()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] square = new int[n, n];

            for (int col = 0; col < n; col++)
            {
                int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int row = 0; row < n; row++)
                {
                    square[row, col] = input[row];
                }
            }

            int primDiagonalSum = 0;
            int secDiagonalSum = 0;
            for (int i = 0; i < n; i++)
            {
                primDiagonalSum += square[i, i];
                secDiagonalSum += square[i, square.GetLength(0) - (1 + i)];

            }

            if (primDiagonalSum > secDiagonalSum)
            {
                Console.WriteLine(primDiagonalSum - secDiagonalSum);
            }
            else
            {
                Console.WriteLine(secDiagonalSum - primDiagonalSum);
            }
        }

        // 02. 2X2 Squares in Matrix
        public static void SquaresInMatrix()
        {
            int[] rowCol = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int count = 0;
            string[,] matrix = new string[rowCol[0], rowCol[1]];
            int a = matrix.Length;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine()
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < rowCol[1]; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    string first = matrix[i, j];
                    string second = matrix[i, j + 1];

                    if (first == second)
                    {
                        string third = matrix[i + 1, j];
                        string fourth = matrix[i + 1, j + 1];

                        if (third == fourth && fourth == first)
                        {
                            count++;
                        }
                    }
                }
            }
            Console.WriteLine(count);
        }

        // 03. Maximal Sum
        public static void MaximalSum()
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int result = int.MinValue;
            int rolIndex = -1;
            int colIndex = -1;

            for (int row = 0; row < size[0] - 2; row++)
            {
                for (int col = 0; col < size[1] - 2; col++)
                {
                    int sum = matrix[row, col]
                         + matrix[row, col + 1]
                         + matrix[row, col + 2]
                         + matrix[row + 1, col]
                         + matrix[row + 1, col + 1]
                         + matrix[row + 1, col + 2]
                         + matrix[row + 2, col]
                         + matrix[row + 2, col + 1]
                         + matrix[row + 2, col + 2];

                    if (sum > result)
                    {
                        rolIndex = row;
                        colIndex = col;
                        result = sum;
                    }
                }
            }

            Console.WriteLine($"Sum = {result}");

            Console.WriteLine($"{matrix[rolIndex, colIndex]} " +
                              $"{matrix[rolIndex, colIndex + 1]} " +
                              $"{matrix[rolIndex, colIndex + 2]}");

            Console.WriteLine($"{matrix[rolIndex + 1, colIndex]} " +
                              $"{matrix[rolIndex + 1, colIndex + 1]} " +
                              $"{matrix[rolIndex + 1, colIndex + 2]}");

            Console.WriteLine($"{matrix[rolIndex + 2, colIndex]} " +
                              $"{matrix[rolIndex + 2, colIndex + 1]} " +
                              $"{matrix[rolIndex + 2, colIndex + 2]}");
        }

        // 04. Matrix Shuffling
        public static void MatrixShuffling()
        {
            long[] cordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            if (cordinates[0] <= 0 || cordinates[1] <= 0)
            {
                return;
            }

            string[,] matrix = new string[cordinates[0], cordinates[1]];

            for (long row = 0; row < cordinates[0]; row++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (long col = 0; col < cordinates[1]; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] splittedCommand = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (splittedCommand[0] == "swap" && splittedCommand.Length == 5)
                {
                    long cordinate1 = long.Parse(splittedCommand[1]);
                    long cordinate11 = long.Parse(splittedCommand[2]);
                    long cordinate2 = long.Parse(splittedCommand[3]);
                    long cordinate22 = long.Parse(splittedCommand[4]);

                    if (cordinate1 < 0
                        || cordinate1 >= cordinates[0]
                        || cordinate11 < 0
                        || cordinate11 >= cordinates[1]
                        || cordinate2 < 0
                        || cordinate2 >= cordinates[0]
                        || cordinate22 < 0
                        || cordinate22 >= cordinates[1])
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                    string temp = matrix[cordinate1, cordinate11];
                    matrix[cordinate1, cordinate11] = matrix[cordinate2, cordinate22];
                    matrix[cordinate2, cordinate22] = temp;
                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (long row = 0; row < matrix.GetLength(0); row++)
            {
                for (long col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        // 05. Snake Moves
        public static void SnakeMoves()
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] isle = new char[size[0], size[1]];
            string snake = Console.ReadLine();
            Queue<char> snakeParts = new Queue<char>();
            int count = 0;

            //Queue filling
            for (int i = 0; i < snake.Length; i++)
            {
                snakeParts.Enqueue(snake[i]);
                count++;

                if (count == size[0] * size[1])
                {
                    break;
                }
                else if (i == snake.Length - 1)
                {
                    i = -1;
                }
            }

            //Matrix filling
            for (int i = 0; i < size[0]; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < size[1]; j++)
                    {
                        isle[i, j] = snakeParts.Dequeue();
                    }
                }
                else
                {
                    for (int k = size[1] - 1; k >= 0; k--)
                    {
                        isle[i, k] = snakeParts.Dequeue();
                    }
                }
            }
            MatrixPrinting(isle);
        }

        //Printing Matrix
        private static void MatrixPrinting(char[,] isle)
        {
            for (int row = 0; row < isle.GetLength(0); row++)
            {
                for (int col = 0; col < isle.GetLength(1); col++)
                {
                    Console.Write($"{isle[row, col]}");
                }

                Console.WriteLine();
            }
        }

        // 06. Jagged Array Manipulator
        public static void JaggedArrayManipulator()
        {
            long rows = long.Parse(Console.ReadLine());

            double[][] matrix = new double[rows][];

            for (long row = 0; row < rows; row++)
            {
                double[] rowInAMatrix = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                matrix[row] = rowInAMatrix;
            }
            //Analyzing
            AnalyzingMatrix(matrix);

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "Add" && command.Length == 4)
                {
                    long row = long.Parse(command[1]);
                    long col = long.Parse(command[2]);
                    long value = long.Parse(command[3]);

                    if (row >= 0 & row <= matrix.Length - 1 && col >= 0 && col <= matrix.Length)
                    {
                        matrix[row][col] += value;
                    }
                }
                else if (command[0] == "Subtract" && command.Length == 4)
                {
                    long row = long.Parse(command[1]);
                    long col = long.Parse(command[2]);
                    long value = long.Parse(command[3]);

                    if (row >= 0 & row <= matrix.Length - 1 && col >= 0 && col <= matrix.Length)
                    {
                        matrix[row][col] -= value;
                    }
                }
            }
            //PrintingMatrix
            PrintingMatrix(matrix);
        }
        private static void PrintingMatrix(double[][] matrix)
        {
            for (long row = 0; row < matrix.Length; row++)
            {
                for (long col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void AnalyzingMatrix(double[][] matrix)
        {
            for (long i = 0; i < matrix.Length - 1; i++)
            {
                if (matrix[i].Length == matrix[i + 1].Length)
                {
                    for (long j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] *= 2;
                        matrix[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (long j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] /= 2;

                    }
                    for (long k = 0; k < matrix[i + 1].Length; k++)
                    {
                        matrix[i + 1][k] /= 2;

                    }
                }
            }
        }

        // 07. *Miner
        public static void Miner()
        {
            int fieldSize = int.Parse(Console.ReadLine());
            char[,] field = new char[fieldSize, fieldSize];
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> commandsCollection = new Queue<string>();
            int startPositionRow = 0;
            int startPositionCol = 0;
            int coalsCoolected = 0;
            int totalCoals = 0;

            //Filling Queue
            for (int i = 0; i < commands.Length; i++)
            {
                commandsCollection.Enqueue(commands[i]);
            }

            //Filling Field
            for (int row = 0; row < fieldSize; row++)
            {
                char[] symbols = Console.ReadLine()
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .Select(char.Parse)
                     .ToArray();

                for (int col = 0; col < fieldSize; col++)
                {
                    field[row, col] = symbols[col];

                    if (symbols[col] == 's')
                    {
                        startPositionRow = row;
                        startPositionCol = col;
                    }
                    else if (symbols[col] == 'c')
                    {
                        totalCoals++;
                    }
                }
            }

            // Commands
            while (commandsCollection.Any())
            {
                string command = commandsCollection.Dequeue();
                if (command == "up")
                {
                    if (startPositionRow - 1 >= 0)
                    {
                        startPositionRow -= 1;
                    }
                }
                else if (command == "down")
                {
                    if (startPositionRow + 1 <= fieldSize - 1)
                    {
                        startPositionRow += 1;
                    }
                }
                else if (command == "left")
                {
                    if (startPositionCol - 1 >= 0)
                    {
                        startPositionCol -= 1;
                    }
                }
                else if (command == "right")
                {
                    if (startPositionCol + 1 <= fieldSize - 1)
                    {
                        startPositionCol += 1;
                    }
                }

                if (field[startPositionRow, startPositionCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({startPositionRow}, {startPositionCol})");
                    return;
                }
                else if (field[startPositionRow, startPositionCol] == 'c')
                {
                    coalsCoolected++;
                    field[startPositionRow, startPositionCol] = '*';

                    if (coalsCoolected == totalCoals)
                    {
                        Console.WriteLine($"You collected all coals! ({startPositionRow}, {startPositionCol})");
                    }
                }
            }

            if (totalCoals > coalsCoolected)
            {
                Console.WriteLine($"{totalCoals - coalsCoolected} coals left. ({startPositionRow}, {startPositionCol})");
            }
        }
        
         // 08. *Bombs
        public static void Bombs()
        {
            long size = long.Parse(Console.ReadLine());

            long[,] matrix = new long[size, size];

            //Filling matrix
            for (long i = 0; i < size; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
                for (long j = 0; j < size; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            Queue<long> bombCordinates = new Queue<long>(Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse));

            while (bombCordinates.Any())
            {
                long bombRow = bombCordinates.Dequeue();
                long bombCol = bombCordinates.Dequeue();

                if (matrix[bombRow, bombCol] > 0)
                {
                    if (bombRow - 1 >= 0)
                    {
                        if (matrix[bombRow - 1, bombCol] > 0)
                        {
                            matrix[bombRow - 1, bombCol] -= matrix[bombRow, bombCol];
                        }
                    }
                    if (bombRow - 1 >= 0 && bombCol - 1 >= 0)
                    {
                        if (matrix[bombRow - 1, bombCol - 1] > 0)
                        {
                            matrix[bombRow - 1, bombCol - 1] -= matrix[bombRow, bombCol];
                        }
                    }
                    if (bombRow - 1 >= 0 && bombCol + 1 >= 0 && bombCol + 1 <= size - 1)
                    {
                        if (matrix[bombRow - 1, bombCol + 1] > 0)
                        {
                            matrix[bombRow - 1, bombCol + 1] -= matrix[bombRow, bombCol];
                        }
                    }
                    if (bombRow + 1 >= 0 && bombRow + 1 <= size - 1 && bombCol - 1 >= 0)
                    {
                        if (matrix[bombRow + 1, bombCol - 1] > 0)
                        {
                            matrix[bombRow + 1, bombCol - 1] -= matrix[bombRow, bombCol];
                        }
                    }
                    if (bombRow + 1 >= 0 && bombRow + 1 <= size - 1 && bombCol + 1 >= 0 && bombCol + 1 <= size - 1)
                    {
                        if (matrix[bombRow + 1, bombCol + 1] > 0)
                        {
                            matrix[bombRow + 1, bombCol + 1] -= matrix[bombRow, bombCol];
                        }
                    }
                    if (bombRow + 1 <= size - 1)
                    {
                        if (matrix[bombRow + 1, bombCol] > 0)
                        {
                            matrix[bombRow + 1, bombCol] -= matrix[bombRow, bombCol];
                        }
                    }
                    if (bombCol - 1 >= 0)
                    {
                        if (matrix[bombRow, bombCol - 1] > 0)
                        {
                            matrix[bombRow, bombCol - 1] -= matrix[bombRow, bombCol];
                        }
                    }
                    if (bombCol + 1 <= size - 1)
                    {
                        if (matrix[bombRow, bombCol + 1] > 0)
                        {
                            matrix[bombRow, bombCol + 1] -= matrix[bombRow, bombCol];
                        }
                    }

                    matrix[bombRow, bombCol] = 0;
                }
            }

            //Cheching for aliving cells
            long count = 0;
            long sum = 0;
            for (long row = 0; row < size; row++)
            {
                for (long col = 0; col < size; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        count++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");

            //Printing the matrix
            for (long row = 0; row < size; row++)
            {
                for (long col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]}" + " ");
                }

                Console.WriteLine();
            }
        }       
    }
}


       
