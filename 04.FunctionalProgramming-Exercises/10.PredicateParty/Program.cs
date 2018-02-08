using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var ppl = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var comms = string.Empty;

            while ((comms = Console.ReadLine()) != "Party!")
            {
                var input = comms.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                var removeOrDouble = input[0];
                var command = input[1];
                var token = input[2];

                Func<string, string> func;

                switch (removeOrDouble)
                {
                    case "Remove":
                        CriteriaRemove(command, ppl, token);
                        break;
                    case "Double":
                        CriteriaDouble(command, ppl, token);
                        break;

                }
            }
            Console.Write(string.Join(", ", ppl));
            Console.WriteLine(" are going to the party!");
        }

        private static void CriteriaDouble(string command, List<string> ppl, string token)
        {
            Func<string, bool> func =

            for (int i = ppl.Count - 1; i >= 0; i--)
            {
                switch (command)
                {
                    case "StartsWith":
                      
                        break;
                    case "EndsWith":

                        break;
                    case "Length":

                        break;

                }
            }
        }

        private static void CriteriaRemove(string command, List<string> ppl, string token)
        {
            Predicate<string> startWith = x => x.StartsWith(token);
            Predicate<string> endWith = x => x.EndsWith(token);
            Predicate<string> lengthRemove = x => x.Length == int.Parse(token);

            switch (command)
            {
                case "StartsWith":
                    ppl.RemoveAll(startWith);
                    break;
                case "EndsWith":
                    ppl.RemoveAll(endWith);
                    break;
                case "Length":
                    ppl.RemoveAll(lengthRemove);
                    break;

            }
        }
    }
}
