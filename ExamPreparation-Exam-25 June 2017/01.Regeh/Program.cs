using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<int> indexes = new List<int>();

            MatchCollection matches = Regex.Matches(input, @"((\[[^\[]+)<(?<first>\d+?)REGEH(?<second>\d+?)>([^\]]+\]))");

            if (matches.Count>0)
            {
                foreach (Match match in matches)
                {
                    var firstNumber = int.Parse(match.Groups["first"].Value);
                    var secondNumber = int.Parse(match.Groups["second"].Value);

                    indexes.Add(firstNumber);
                    indexes.Add(secondNumber);
                }
            }

            var index = 0;

            foreach (var number in indexes)
            {
                index += number;

                var currIndex = index % input.Length;
                Console.Write(input[currIndex]);
            }
        }
    }
}
