using System;

public class Program
{
    static void Main(string[] args)
    {
        var phone = new Smartphone("Smartphone");

        TestNumbers(phone);

        TestUrls(phone);

    }

    private static void TestUrls(Smartphone phone)
    {
        var urls = Console.ReadLine().Split();

        foreach (var url in urls)
        {
            Console.WriteLine(phone.Browse(url));
        }
    }

    private static void TestNumbers(Smartphone phone)
    {
        var numbers = Console.ReadLine().Split();

        foreach (var number in numbers)
        {
            Console.WriteLine(phone.Call(number));
        }
    }
}

