using MyStack;
using System;
using System.Linq;

namespace Stack
{
   public class Program
    {
       public static void Main(string[] args)
        {
            MyStack<int> collection = new MyStack<int>();

            string input;
            while((input = Console.ReadLine()) != "END")
            {
                string[] inputArrgs = input
                    .Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if(inputArrgs[0] == "Push")
                {
                    var pushArrgs = inputArrgs.Skip(1).Select(int.Parse).ToArray();
                    collection.Push(pushArrgs);
                }
                else if(inputArrgs[0] == "Pop")
                {
                    if(collection.Count() == 0)
                    {
                        Console.WriteLine("No elements");
                        continue;
                    }

                    collection.Pop();
                }                
            }

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
