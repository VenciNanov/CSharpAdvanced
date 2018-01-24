using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReverseNumbersWithAStack
{
    class Program
    {
        static void Main(string[] args)
        {

            var stack = new Stack<int>();

            Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(strNumber => stack.Push(int.Parse(strNumber)));

            Console.WriteLine(string.Join(" ",stack));
            
        }
    }
}
