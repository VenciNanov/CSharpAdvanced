using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.CubicAssault
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, long>>();

            var lines = string.Empty;

            while ((lines = Console.ReadLine()) != "Count em all")
            {
                var input = lines.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                var regionName = input[0];
                var type = input[1];
                var typeCount = long.Parse(input[2]);

                if (!dict.ContainsKey(regionName))
                {
                    dict.Add(regionName, new Dictionary<string, long>()
                    {
                        {"Green", 0L },
                        {"Red", 0L },
                        {"Black", 0L }
                    });
                }

                dict[regionName][type] += typeCount;
                

                if (dict[regionName]["Green"] >= 1000000)
                {
                    var greenAmount = dict[regionName]["Green"];
                    var move = greenAmount / 1000000;

                    dict[regionName]["Green"] = greenAmount % 1000000;
                    dict[regionName]["Red"] += move;
                }

                if (dict[regionName]["Red"] >= 1000000)
                {
                    var redAmount = dict[regionName]["Red"];
                    var move = redAmount / 1000000;

                    dict[regionName]["Red"] = redAmount % 1000000;
                    dict[regionName]["Black"] += move;
                }
            }

            dict = dict.OrderByDescending(x => x.Value["Black"]).ThenBy(x => x.Key.Length).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);

            foreach (var region in dict)
            {
                Console.WriteLine(region.Key);
                foreach (var type in region.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"-> {type.Key} : {type.Value}");
                }
            }
        }
    }
}
