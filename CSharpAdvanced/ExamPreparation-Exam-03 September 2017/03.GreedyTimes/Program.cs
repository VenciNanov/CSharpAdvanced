using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.GreedyTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            var capacity = long.Parse(Console.ReadLine());


            Dictionary<string, long> gold = new Dictionary<string, long>();
            Dictionary<string, long> gem = new Dictionary<string, long>();
            Dictionary<string, long> cash = new Dictionary<string, long>();

            var safe = Console.ReadLine();

            var pattern = @"(?<name>[A-Za-z]+)\s(?<qty>[0-9]+)";
            MatchCollection matches = Regex.Matches(safe, pattern, RegexOptions.IgnoreCase);

            foreach (Match item in matches)
            {
                var name = item.Groups["name"].Value;
                var amount = long.Parse(item.Groups["qty"].Value);
                var currGold = gold.Values.Sum();
                var currGems = gem.Values.Sum();
                var currCash = cash.Values.Sum();

                if (currGold+currGems+currCash+amount>capacity)
                {
                    continue;
                }

                if (name.ToLower()=="gold")
                {
                    if (!gold.ContainsKey(name))
                    {
                        gold[name] = 0;
                    }

                    gold[name] += amount;
                   
                }

                else if (name.Length>3&&name.Substring(name.Length-3).ToLower()=="gem")
                {
                    if (currGems+amount<=currGold)
                    {
                        if (!gem.ContainsKey(name))
                        {
                            gem[name] = 0;
                        }
                        gem[name] += amount;
                    }

                }
                else if (name.Length==3)
                {
                    if (currCash+amount<=currGems)
                    {
                        if (!cash.ContainsKey(name))
                        {
                            cash[name] = 0;
                        }
                        cash[name] += amount;
                    }
                }

            }

            List<Dictionary<string, long>> bag = new List<Dictionary<string, long>>();

            if (gold.Count>0)
            {
                bag.Add(gold);
            }
            if (gem.Count>0)
            {
                bag.Add(gem);
            }
            if (cash.Count>0)
            {
                bag.Add(cash);
            }

            foreach (var item in bag.OrderByDescending(x=>x.Values.Sum()))
            {
                var groupName = string.Empty;

                if (item.Count>0)
                {
                    if (item.Keys.First().ToLower()=="gold")
                    {
                        groupName = "Gold";
                    }
                    else if (item.Keys.First().Length==3)
                    {
                        groupName = "Cash";
                    }
                    else
                    {
                        groupName = "Gem";
                    }
                }

                Console.WriteLine($"<{groupName}> ${item.Values.Sum()}");
                foreach (var thing in item.OrderByDescending(x=>x.Key).ThenBy(x=>x.Value))
                {
                    Console.WriteLine($"##{thing.Key} - {thing.Value}");
                }
            }
        }
    }
}
