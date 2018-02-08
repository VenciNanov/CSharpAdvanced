using System;
using System.Linq;

namespace _02.CryptoMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            long lenght = input.Count;
            long maxLenght = 0;

            for (int i = 1; i < lenght; i++)
            {
                for (int j = 0; j < lenght; j++)
                {
                    var currMax = 1;

                    var currentIndex = j;
                    var nextIndex = (currentIndex + i) % input.Count;
                    while (input[nextIndex]>input[currentIndex])
                    {
                        currMax++;
                        currentIndex = nextIndex;
                        nextIndex = (currentIndex + i) % input.Count;
                    }
                    if (maxLenght<currMax)
                    {
                        maxLenght = currMax;
                    }
                }
            }
            Console.WriteLine(maxLenght);
        }
    }
}
