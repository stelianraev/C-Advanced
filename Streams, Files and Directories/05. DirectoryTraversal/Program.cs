using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace _05._DirectoryTraversal
{
    public class Program
    {
       public static void Main(string[] args)
        {
            string[] directories = Directory.GetFiles(@"C:\Users\steli\Desktop\S.R\Pics");
            Dictionary<string, Dictionary<string, double>> files = new Dictionary<string, Dictionary<string, double>>();

            for (int i = 0; i < directories.Length; i++)
            {
               long size = new FileInfo(directories[i]).Length;                
               string fileName = directories[i].Split("\\").Last();
               string ext = directories[i].Split(".").Last();

                if (!files.ContainsKey(ext))
                {
                    files[ext] = new Dictionary<string, double>();

                    if (!files[ext].ContainsKey(fileName))
                    {
                        files[ext][fileName] = size;
                    }
                }
                else
                {
                    files[ext].Add(fileName, size);
                }
            }

            foreach (var file in files)
            {
                Console.WriteLine($".{file.Key}");

                foreach (var info in file.Value)
                {
                    Console.WriteLine($"--{info.Key} - {info.Value}");
                }
            }
        }
    }
}
