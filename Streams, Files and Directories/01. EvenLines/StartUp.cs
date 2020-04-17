using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Steams
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("./text.txt"))
            {
                int count = 0;
                char[] symbols = { '-', ',', '.', '!', '?' };
                while (true)
                {
                    string part = reader.ReadLine();

                    if (part == null)
                    {
                        break;
                    }

                    if (count % 2 == 0)
                    {
                        part = ReplaceSymbol(symbols, '@', part);

                        part = ReverseWords(part);

                        using (StreamWriter writer = new StreamWriter("./output.txt", true))
                        {
                            writer.WriteLine($"{part}");
                            writer.Flush();
                        }
                    }
                    count++;
                }
            }

        }
        static string ReplaceSymbol(char[] symbols, char replacement, string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (symbols.Contains(str[i]))
                {
                    str = str.Replace(str[i], replacement);
                }
            }

            return str;
        }
        static string ReverseWords(string str)
        {
            StringBuilder sb = new StringBuilder();

            string[] words = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                sb.Append(words[words.Length - i - 1]);
                sb.Append(' ');
            }

            return sb.ToString().TrimEnd();
        }
    }
}
