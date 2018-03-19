using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.CubicMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = string.Empty;

            Regex regex = new Regex(@"^(?<frontIndex>\d*)(?<text>[a-zA-Z]+)(?<lastIndex>[^a-zA-Z]*)$");

            while ((input = Console.ReadLine()) != "Over!")
            {
                var n = int.Parse(Console.ReadLine());

                if (!regex.IsMatch(input))
                {
                    continue;
                }

                Match match = regex.Match(input);

                var text = match.Groups["text"].Value;
                if (text.Length!=n)
                {
                    continue;
                }

                var frontIndex = match.Groups["frontIndex"].Value;
                var backIndex = match.Groups["lastIndex"].Value;

                var numbers = match.Groups["frontIndex"].Value + match.Groups["lastIndex"].Value;

                List<int> indexes = new List<int>();

                for (int i = 0; i < numbers.Length; i++)
                {
                    int currIndex;

                    bool isNumber = int.TryParse(numbers[i].ToString(), out currIndex);

                    if (isNumber)
                    {
                        indexes.Add(currIndex);
                    }
                }
                StringBuilder sb = new StringBuilder();

                foreach (var index in indexes)
                {
                    if (index<n&&index>=0)
                    {
                        sb.Append(text[index]);
                    }
                    else
                    {
                        sb.Append(" ");
                    }
                }
                Console.WriteLine($"{text} == {sb.ToString()}");
                


            }
        }

    }
}
