using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Startup
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var employees = new Stack<Empolyee>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var email = "n/a";
            var age = -1;

            if (input.Length > 4)
            {
                int parsed;
                var isDigit = int.TryParse(input[4], out parsed);

                if (isDigit)
                {
                    age = parsed;
                }
                else
                {
                    email = input[4];
                }

                if (input.Length > 5)
                {
                    if (isDigit)
                    {
                        email = input[5];
                    }
                    else
                    {
                        age = int.Parse(input[5]);
                    }
                }
            }
            employees.Push(new Empolyee(input[0],
               decimal.Parse(input[1]),
               input[2],
               input[3],
               email,
               age));
        }
        var highestPaidDepartment = employees.GroupBy(e => e.Department)
            .OrderByDescending(g => g.Select(e => e.Salary).Sum()).First();
        Console.WriteLine($"Highest Average Salary: {highestPaidDepartment}");
        Console.WriteLine(string.Join(Environment.NewLine,highestPaidDepartment.OrderByDescending(e=>e.Salary)
            .Select(e=>$"{e.Name} {e.Salary:f2} {e.Email} {e.Age}")));
    }
}

