using System;
using System.Collections;
using System.Collections.Generic;

namespace _02.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var elements = input.Split(' ');

            var stack = new Stack<string>();

            for (int i = elements.Length - 1; i >= 0; i--)
            {
                stack.Push(elements[i]);
            }

            while (stack.Count > 1)
            {
                var leftOperand = int.Parse(stack.Pop());
                var operand = stack.Pop();
                var rightOperand = int.Parse(stack.Pop());

                switch (operand)
                {
                    case "+":
                        stack.Push((leftOperand + rightOperand).ToString());
                        break;

                    case "-":
                        stack.Push((leftOperand - rightOperand).ToString());
                        break;
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
