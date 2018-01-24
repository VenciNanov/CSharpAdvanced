using System;
using System.Collections.Generic;

namespace _09.StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());

            var stack = new Stack<long>();

            stack.Push(0);

            long a = 0;
            long b = 1;

            long result = 0;

            for (int i = 0; i < n -1; i++)
            {
                long temp = a;
                a = b;
                b = temp + b;
                result = b;
            }
            Console.WriteLine(result);
            //Console.WriteLine(stack.First());
        }
    }
}
