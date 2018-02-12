﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var stack = new Stack<char>(input.ToCharArray());

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop().ToString());
            }


        }
    }
}
