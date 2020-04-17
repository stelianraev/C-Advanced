using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._WordCount
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] words = File.ReadAllLines("./words.txt");
            string[] text = File.ReadAllLines("./text.txt");

            Dictionary<string, int> dic = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (!dic.ContainsKey(words[i]))
                {
                    dic[words[i]] = 0;
                }
            }

            for (int i = 0; i < text.Length; i++)
            {
                string temp = text[i].ToLower();

                var wordsForCheck = temp
                    .Split(new char[] { '-', ',', '.', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < wordsForCheck.Length; j++)
                {
                    if (dic.ContainsKey(wordsForCheck[j]))
                    {
                        dic[wordsForCheck[j]]++;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach (var item in dic.OrderByDescending(x => x.Key))
            {
                sb.Append($"{item.Key} - {item.Value}");
                sb.AppendLine();
            }           

            File.WriteAllText("./actualResults.txt.", sb.ToString());

            string[] expectedText = File.ReadAllLines("./expectedResult.txt");
            string[] actualText = File.ReadAllLines("./actualResults.txt");

            bool Same = false;

            for (int i = 0; i < expectedText.Length; i++)
            {
                if (actualText.Contains(expectedText[i]))
                {
                    Same = true;
                }
                else
                {
                    Same = false;
                }
            }

            Console.WriteLine(Same);
        }
    }
}
