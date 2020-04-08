
namespace ExamPrep
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            CupsAndBottles();
        }

        // 01. Basic Stack Operations
        public static void BasicStackOperations()
        {
            var operations = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            var numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            Stack<int> stack = new Stack<int>();

            int pushNums = operations[0];
            int popNums = operations[1];
            int lookingForNumber = operations[2];

            if (pushNums <= 0)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = 0; i < pushNums; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < popNums; i++)
            {
                stack.Pop();

                if (stack.Count == 0)
                {
                    Console.WriteLine(0);
                    return;
                }
            }

            if (stack.Contains(lookingForNumber))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }

        // 02. Basic Queue Operations
        public static void BasicQueueOpearations()
        {
            Queue<int> queue = new Queue<int>();

            int[] commands = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int quequeCount = commands[0];
            int dequeueCount = commands[1];
            int lookingForElement = commands[2];

            if (quequeCount == 0)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = 0; i < quequeCount; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < dequeueCount; i++)
            {
                queue.Dequeue();

                if (queue.Count == 0)
                {
                    Console.WriteLine(0);
                    return;
                }
            }

            if (queue.Contains(lookingForElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }

        // 03. Maximum and Minimum Elements
        public static void MaxAndMinElements()
        {
            Stack<int> stack = new Stack<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                if (command[0] == 1)
                {
                    stack.Push(command[1]);
                }
                else if (command[0] == 2)
                {
                    if (!(stack.Count == 0))
                    {
                        stack.Pop();
                    }
                }
                else if (command[0] == 3)
                {
                    if (!(stack.Count == 0))
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                else if (command[0] == 4)
                {
                    if (!(stack.Count == 0))
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }

            Console.WriteLine(String.Join(", ", stack));
        }

        // 04. Fast Food
        public static void FastFood()
        {
            Queue<int> queue = new Queue<int>();
            int quantityFood = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            Console.WriteLine(orders.Max());

            for (int i = 0; i < orders.Count; i++)
            {
                queue.Enqueue(orders[i]);
            }

            for (int i = 0; i < orders.Count; i++)
            {
                int temp = queue.Peek();

                if (temp <= quantityFood)
                {
                    quantityFood -= orders[i];

                    queue.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.Write($"Orders left: ");
                Console.WriteLine(String.Join(" ", queue));
            }
        }

        // 05. Fashion Boutique
        public static void FashionBoutique()
        {
            Stack<int> stack = new Stack<int>();

            var clothes = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            int count = 0;
            int sum = 0;

            for (int i = 0; i < clothes.Length; i++)
            {
                stack.Push(clothes[i]);
            }

            while (stack.Count != 0)
            {
                var temp = stack.Peek();
                sum += temp;

                if (sum <= rackCapacity)
                {
                    stack.Pop();
                }
                else
                {
                    count++;
                    sum = 0;
                }
            }
            count++;

            Console.WriteLine(count);
        }

        // 06. Songs Queue
        public static void SongsQueue()
        {
            Queue<string> queue = new Queue<string>();

            string[] songs = Console.ReadLine().Split(", ");

            for (int i = 0; i < songs.Length; i++)
            {
                queue.Enqueue(songs[i]);
            }

            while (queue.Count != 0)
            {
                string command = Console.ReadLine();

                if (command == "Play")
                {
                    queue.Dequeue();

                }
                else if (command == "Show")
                {
                    Console.WriteLine(String.Join(", ", queue));
                }
                else
                {
                    var temp = command.Remove(0, 4);

                    if (!queue.Contains(temp))
                    {
                        queue.Enqueue(temp);
                    }
                    else
                    {
                        Console.WriteLine($"{temp} is already contained!");
                    }
                }
            }
            Console.WriteLine("No more songs!");
        }

        // 07. Truck Tour
        public static void TruckTour()
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();
            FillQueue(n, pumps);

            int counter = 0;

            while (true)
            {
                int fuelAmount = 0;
                bool foundPoint = true;
                for (int i = 0; i < n; i++)
                {
                    int[] currentPump = pumps.Dequeue();
                    fuelAmount += currentPump[0];

                    if (fuelAmount < currentPump[1])
                    {
                        foundPoint = false;
                    }

                    fuelAmount -= currentPump[1];

                    pumps.Enqueue(currentPump);
                }

                if (foundPoint)
                {
                    break;
                }

                counter++;

                pumps.Enqueue(pumps.Dequeue());
            }

            Console.WriteLine(counter);
        }

        private static void FillQueue(int n, Queue<int[]> pumps)
        {
            for (int i = 0; i < n; i++)
            {
                int[] currentPump = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();

                pumps.Enqueue(currentPump);
            }
        }

        // 08. Balanced Parentheses
        public static void BalancedParentheses()
        {
            var input = Console.ReadLine();

            Queue<char> queue = new Queue<char>(input);

            int counter = 0;
            bool check = true;

            if (queue.Count % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            while (queue.Any())
            {
                var first = queue.Dequeue();
                var next = queue.Peek();

                if (first == '{')
                {
                    if (next == '}')
                    {
                        queue.Dequeue();
                        counter = 0;
                        continue;
                    }
                    else
                    {
                        queue.Enqueue(first);
                    }
                }
                else if (first == '(')
                {
                    if (next == ')')
                    {
                        queue.Dequeue();
                        counter = 0;
                        continue;
                    }
                    else
                    {
                        queue.Enqueue(first);
                    }
                }
                else if (first == '[')
                {
                    if (next == ']')
                    {
                        queue.Dequeue();
                        counter = 0;
                        continue;
                    }
                    else
                    {
                        queue.Enqueue(first);
                    }
                }
                else
                {
                    queue.Enqueue(first);
                }

                counter++;

                if (counter == queue.Count)
                {
                    check = false;
                    break;
                }
            }

            if (check)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        // 09. Simple Text Editor
        public static void SimpleTextEditor()
        {
            Stack<string> stack = new Stack<string>();
            int n = int.Parse(Console.ReadLine());
            string text = "";

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                string command = input[0];

                if (command == "1")
                {
                    stack.Push(text);
                    text += input[1];
                }
                else if (command == "2")
                {
                    int index = int.Parse(input[1]);

                    if (index > 0 && index <= text.Length)
                    {
                        stack.Push(text);
                        for (int j = 0; j < index; j++)
                        {
                            text = text.Remove(text.Length - 1);
                        }
                    }
                }
                else if (command == "3")
                {
                    int index = int.Parse(input[1]);
                    index -= 1;
                    if (index >= 0 && index <= text.Length)
                    {
                        Console.WriteLine(text[index]);
                    }
                }
                else if (command == "4")
                {
                    if (stack.Count != 0)
                    {
                        var temp = stack.Pop();
                        text = temp;
                    }
                }
            }
        }

        // 10. Crossroads
        public static void Crossroads()
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            var carsToPass = new Queue<string>();
            int counter = 0;

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command != "green")
                {
                    carsToPass.Enqueue(command);
                }
                else
                {
                    int greenLight = greenLightDuration;
                    int freePass = freeWindow;


                    while (carsToPass.Any())
                    {
                        if (greenLight >= carsToPass.Peek().Length)
                        {
                            greenLight -= carsToPass.Dequeue().Length;
                            counter++;
                        }
                        else if (greenLight < carsToPass.Peek().Length)
                        {
                            int timeLeft = greenLight + freePass;

                            if (greenLight <= 0)
                            {
                                break;
                            }
                            else if (timeLeft > 0 && timeLeft >= carsToPass.Peek().Length)
                            {
                                string car = carsToPass.Dequeue();
                                timeLeft -= car.Length;
                                counter++;
                                greenLight = 0;
                                freePass = 0;
                            }
                            else if (timeLeft > 0 && timeLeft < carsToPass.Peek().Length)
                            {
                                string car = carsToPass.Dequeue();

                                Console.WriteLine("A crash happened!");
                                int hit = timeLeft;
                                Console.WriteLine($"{car} was hit at {car[hit]}.");
                                return;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{counter} total cars passed the crossroads.");
        }

        // 11. Key Revolver
        public static void KeyRevolver()
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarelSize = int.Parse(Console.ReadLine());
            int bulletCount = 0;

            Queue<int> locksCollection = new Queue<int>();
            Stack<int> bulletCollection = new Stack<int>();

            int[] bullets = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int inteligenceValue = int.Parse(Console.ReadLine());

            for (int i = 0; i < bullets.Length; i++)
            {
                bulletCollection.Push(bullets[i]);
            }

            for (int i = 0; i < locks.Length; i++)
            {
                locksCollection.Enqueue(locks[i]);
            }

            int gunBarel = gunBarelSize;

            while (bulletCollection.Any() && locksCollection.Any())
            {
                int bullet = bulletCollection.Pop();
                int locked = locksCollection.Peek();
                bulletCount += bulletPrice;

                if (bullet <= locked)
                {
                    Console.WriteLine("Bang!");
                    locksCollection.Dequeue();
                    gunBarel--;
                }
                else
                {
                    Console.WriteLine("Ping!");
                    gunBarel--;
                }
                if (gunBarel <= 0 && bulletCollection.Any())
                {
                    Console.WriteLine("Reloading!");
                    gunBarel = gunBarelSize;
                }
            }
            if (bulletCollection.Count >= 0 && locksCollection.Count == 0)
            {
                Console.WriteLine($"{bulletCollection.Count} bullets left. Earned ${inteligenceValue - bulletCount}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksCollection.Count}");
            }
        }

        // 12. Cups and Bottles
        public static void CupsAndBottles()
        {
            int[] cupCapacity = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] filledBottles = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Queue<int> cups = new Queue<int>();
            Stack<int> bottles = new Stack<int>();

            int wasted = 0;

            for (int i = 0; i < cupCapacity.Length; i++)
            {
                cups.Enqueue(cupCapacity[i]);
            }

            for (int i = 0; i < filledBottles.Length; i++)
            {
                bottles.Push(filledBottles[i]);
            }

            while (bottles.Any() && cups.Any())
            {
                int queuedBottle = bottles.Peek();
                int queuedCup = cups.Peek();

                if (queuedCup <= 0)
                {
                    cups.Dequeue();
                }
                else if (queuedCup > queuedBottle)
                {
                    while (queuedCup > 0 && bottles.Any())
                    {
                        queuedCup -= bottles.Pop();
                       
                        if(queuedCup <= 0)
                        {
                            wasted -= queuedCup;
                            cups.Dequeue();
                            break;
                        }
                    }
                }
                else if (queuedBottle >= queuedCup)
                {
                    wasted += queuedBottle - queuedCup;
                    cups.Dequeue();
                    bottles.Pop();
                }
            }

            if (bottles.Count >= 0 && cups.Count == 0)
            {
                Console.Write("Bottles: ");
                Console.WriteLine(String.Join(" ", bottles));
                Console.WriteLine($"Wasted litters of water: {wasted}");
            }
            else
            {
                Console.Write("Cups: ");
                Console.WriteLine(String.Join(" ", cups));
                Console.WriteLine($"Wasted litters of water: {wasted}");
            }
        }
    }
}