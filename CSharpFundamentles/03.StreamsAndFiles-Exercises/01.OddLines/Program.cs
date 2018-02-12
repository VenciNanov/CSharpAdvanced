using System;
using System.IO;

namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"D:\CSharpAdvanced\03.StreamsAndFiles-Exercises\Resources\text.txt");
            using (reader)
            {
                var lineCounter = 0;
                var line = reader.ReadLine();
                while (line!=null)
                {
                    lineCounter++;
                    if (lineCounter%2==0)
                    {
                        Console.WriteLine(line);
                    }
                    line = reader.ReadLine();
                }
            }
        }
    }
}
