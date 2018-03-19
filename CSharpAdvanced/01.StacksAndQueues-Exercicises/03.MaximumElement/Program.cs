using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            var maxStack = new Stack<int>();

            var maxEl = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var command = input[0];


                switch (command)
                {
                    case 1:
                        {
                            if (maxEl < input[1])
                            {
                                maxEl = input[1];
                                maxStack.Push(maxEl);
                            }
                            stack.Push(input[1]);
                        }
                        break;
                    case 2:
                        {
                            if (stack.Peek() == maxStack.Peek() && maxStack.Count > 0)
                            {
                                maxStack.Pop();
                                if (maxStack.Count > 0)
                                {
                                    maxEl = maxStack.Peek();
                                }
                                else
                                {
                                    maxEl = int.MinValue;
                                }
                            }
                            stack.Pop();
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine(maxStack.Peek());
                        }
                        break;
                }
            }
        }
    }
}
