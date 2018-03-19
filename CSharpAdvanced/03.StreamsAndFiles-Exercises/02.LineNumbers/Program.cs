using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var reader = new StreamReader(@"D:\CSharpAdvanced\03.StreamsAndFiles - Exercises\Resources\text.txt"))
            {
                using (var writer = new StreamWriter(@"D:\CSharpAdvanced\03.StreamsAndFiles-Exercises\Resources\output.txt"))
                {
                    var line = reader.ReadLine();
                    var lineCounter = 0;
                    while (line!=null)
                    {
                        lineCounter++;

                        writer.WriteLine($"Line {lineCounter}: {line}");

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
            
