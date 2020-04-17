using System;
using System.IO;

namespace _02._LineNumbers
{
   public class StartUp
    {
       public static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("./text.txt"))
            {
                int count = 1;
                while (true)
                {
                    string textLine = reader.ReadLine();

                    if(textLine == null)
                    {
                        break;
                    }

                    int letters = 0;
                    int marks = 0;

                    for (int i = 0; i < textLine.Length; i++)
                    {
                        if (Char.IsLetterOrDigit(textLine[i]))
                        {
                            letters++;
                        }
                        else if (textLine[i] == '-'
                            || textLine[i] == '.'
                            || textLine[i] == ','
                            || textLine[i] == '?'
                            || textLine[i] == '!'
                            || textLine[i] == '\'')
                        {
                            marks++;
                        }
                    }
                    using(StreamWriter writer = new StreamWriter("./output.txt"))
                    {
                        writer.Write($"Line {count}: {textLine} ({letters})({marks})");
                        Console.WriteLine($"Line {count}: {textLine} ({letters})({marks})");
                    }

                    count++;
                }
            }
        }
    }
}
