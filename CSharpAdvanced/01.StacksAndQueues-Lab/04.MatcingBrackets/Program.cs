using System;
using System.Collections;
using System.Collections.Generic;

namespace _04.MatcingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];
                if (ch == '(')
                {
                    stack.Push(i);
                }
                else if (ch==')')
                {
                    var startIndex = stack.Pop();
                    var content = input.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(content);
                }

            }
        }
    }
}
