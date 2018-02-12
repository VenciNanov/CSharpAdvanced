using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.CryptoBlockChain
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var text = string.Empty;

            var numbers = new List<int>();

            for (int i = 0; i < n; i++)
            {
                text += Console.ReadLine();
            }

            var chainsPattern = @"\[.*?]|{.+?}";

            var numbersPattern = @"\d+";

            MatchCollection chainCollection = Regex.Matches(text, chainsPattern);

            var ascii = new List<string>();

            foreach (Match collection in chainCollection)
            {
                var numbersChain = Regex.Match(collection.ToString(), numbersPattern);

                if (numbersChain.Length % 3 == 0 && numbersChain.Length > 3)
                {
                    ascii.Add(numbersChain.ToString());

                    var asciiNumbers = new List<int>();

                    for (int i = 0; i < ascii.Count; i++)
                    {
                        MatchCollection wordsColl = Regex.Matches(ascii[i].ToString(), @"\d{3}");

                        foreach (Match number in wordsColl)
                        {
                            var result = int.Parse(number.ToString());

                            Console.Write((char)Math.Abs((result - collection.Length)));

                        }
                    }
                    ascii.Clear();
                }
            }
            Console.WriteLine();
        }
    }
}
