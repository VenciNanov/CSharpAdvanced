using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.HitList
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, SortedDictionary<string, string>>();

            var index = int.Parse(Console.ReadLine());

            var line = string.Empty;
            while ((line = Console.ReadLine()) != "end transmissions")
            {
                var input = line.Split(new char[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);
                var name = input[0];

                if (!dict.ContainsKey(name))
                {
                    dict[name] = new SortedDictionary<string, string>();
                }


                var tokens = line.Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).Take(line.Length - 1 / 2).ToList();



                if (tokens.Count == 1)
                {
                    var information = tokens[0].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    var infoKey = information[0];
                    var infoVal = information[1];
                    if (dict[name].ContainsKey(infoKey))
                    {
                        dict[name][infoKey] = infoVal;
                    }
                    else
                    {
                        dict[name][infoKey] = infoVal;
                    }
                }
                else
                {
                    foreach (var item in tokens)
                    {
                        var information = item.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                        var infoKey = information[0];
                        var infoVal = information[1];

                        dict[name][infoKey] = infoVal;

                    }
                }
            }

            var killing = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var personToKill = killing[1];

            var infoIndex = 0;

            Console.WriteLine($"Info on {personToKill}:");
            
            foreach (var infoKey in dict[personToKill])
            {
                infoIndex += infoKey.Key.Count();
                infoIndex += infoKey.Value.Count();
                Console.WriteLine($"---{infoKey.Key}: {infoKey.Value}");
            }
            Console.WriteLine($"Info index: {infoIndex}");
            if (infoIndex>=index)
            {
                Console.WriteLine("Proceed");
            }
            else
            {

                Console.WriteLine($"Need {index-infoIndex} more info.");
            }
            
        }
    }
}
