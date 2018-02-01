using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Func<double[], double> minFunc = GetMin;

            var minNumber = minFunc(input);
            Console.WriteLine(minNumber);
        }

        private static double GetMin(double[] arg)
        {
            var min = double.MaxValue;

            foreach (var num in arg)
            {
                if (num<min)
                {
                    min = num;
                }
            }
            return min;
        }
    }
}
