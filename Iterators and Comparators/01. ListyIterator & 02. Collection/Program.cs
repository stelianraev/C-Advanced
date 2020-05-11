using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _01._ListyIterator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> people = new List<string>();
            ListyIterator<string> list = new ListyIterator<string>(people);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var inputArrgs = command
                      .Split(" ")
                      .ToArray();

                if (inputArrgs[0] == "Create")
                {
                    for (int i = 1; i < inputArrgs.Length; i++)
                    {
                        people.Add(inputArrgs[i]);
                    }
                }
                else if(inputArrgs[0] == "Move")
                {
                    Console.WriteLine(list.Move());
                }
                else if(inputArrgs[0] == "HasNext")
                {
                    Console.WriteLine(list.HasNext());
                }
                else if(inputArrgs[0] == "Print")
                {
                    Console.WriteLine(list.Print());
                }
                else if(inputArrgs[0] == "PrintAll")
                {
                    foreach (var item in list)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}

