using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.BalancedParenthess
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<char>();

            var input = Console.ReadLine();
            var flag = true;

            foreach (char para in input)
            {
                switch (para)
                {
                    case '[':
                    case '(':
                    case '{':
                        stack.Push(para);
                        break;

                    case '}':
                        if (!stack.Any())
                        {
                            flag = false;
                        }
                        else if (stack.Pop() != '{')
                        {
                            flag = false;
                        }
                        break;

                    case ')':
                        if (!stack.Any())
                        {
                            flag = false;
                        }
                        else if (stack.Pop() != '(')
                        {
                            flag = false;
                        }
                        break;

                    case ']':
                        if (!stack.Any())
                        {
                            flag = false;
                        }
                        else if (stack.Pop() != '[')
                        {
                            flag = false;
                        }
                        break;
                }

                if (!flag)
                {
                    break;
                }

                
            }
            Console.WriteLine(flag ? "YES" : "NO");

        }
    }
}
