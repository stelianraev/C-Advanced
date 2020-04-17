using System;
using System.IO.Compression;

namespace _06._ZipAndExtract
{
   public class Program
    {
       public static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory("./copyMe.png", ".");
        }
    }
}
