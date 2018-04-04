using System;

public class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split();

        var fullName = input[0] + " " + input[1];
        var address = input[2];
        var town = input[3];

        Threeuple<string, string, string> firstThreeuple = new Threeuple<string, string, string>(fullName, address, town);
        
        
        input = Console.ReadLine().Split();
        var PersonName = input[0];
        var beers = int.Parse(input[1]);
        bool isDrunk = input[2] == "drunk" ? true : false;

        Threeuple<string, int, bool> secondThreeuple = new Threeuple<string, int, bool>(PersonName, beers, isDrunk);

        input = Console.ReadLine().Split();
        var name = input[0];
        var balance = double.Parse(input[1]);
        var bankName = input[2];

        Threeuple<string, double, string> thirdThreeuple = new Threeuple<string, double, string>(name, balance, bankName);


        Console.WriteLine(firstThreeuple);
        Console.WriteLine(secondThreeuple);
        Console.WriteLine(thirdThreeuple);
        

        

    }
}