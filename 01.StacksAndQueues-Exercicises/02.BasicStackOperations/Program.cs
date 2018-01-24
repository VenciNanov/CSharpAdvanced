using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').ToArray();
            var pushStack = int.Parse(input[0]);
            var popStack = int.Parse(input[1]);
            var numberToFind = int.Parse(input[2]);

            var numbers = Console.ReadLine().Split(' ').ToArray();
            var parsedNumbers = Array.ConvertAll(numbers, int.Parse);

            var stack = new Stack<int>();

            for (int i = 0; i < pushStack; i++)
            {
                stack.Push(parsedNumbers[i]);
            }

            for (int i = 0; i < popStack; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(numberToFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }


        }
    }
}
