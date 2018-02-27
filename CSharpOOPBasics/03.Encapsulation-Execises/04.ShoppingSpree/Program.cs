using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var persons = new List<Person>();
        var products = new Dictionary<string, Product>();

        try
        {
            GetPeople(persons);
            GetProducts(products);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        PrintAndShopping(persons, products);
    }

    public static void PrintAndShopping(List<Person> persons, Dictionary<string, Product> products)
    {
        while (Shopping(out string personName, out string productName))
        {
            if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(personName))
            {
                Console.WriteLine("Name cannot be empty");
                return;
            }

            Person person = persons.FirstOrDefault(x => x.Name == personName);
            Product product = products[productName];

            if (person.TryAddProduct(product))
            {
                Console.WriteLine($"{person.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{person.Name} can't afford {product.Name}");
            }
        }

        foreach (var person in persons)
        {
            Console.WriteLine($"{person.ToString()}");
        }
    }

    public static bool Shopping(out string personName, out string productName)
    {
        personName = null;
        productName = null;

        string input = Console.ReadLine();
        if (input == "END")
        {
            return false;
        }

        var data = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (data.Length==2)
        {
            personName = data[0];
            productName = data[1];
        }

        return true;
    }

    public static void GetProducts(Dictionary<string, Product> products)
    {
        var productsInput = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        foreach (var data in productsInput)
        {
            var productInfo = data.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

            if (productInfo.Length == 1)
            {
                throw new ArgumentException($"Name cannot be empty.");
            }
            var name = productInfo[0];
            var cost = decimal.Parse(productInfo[1]);

            if (products.ContainsKey(name))
            {
                products[name] = null;
            }

            try
            {
                products[name] = new Product(name, cost);
            }
            catch (ArgumentException ex)
            {

                throw new ArgumentException($"{ex.Message}");
            }
        }
    }

    public static void GetPeople(List<Person> persons)
    {
        var personInput = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string data in personInput)
        {
            var personInfo = data.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

            if (personInfo.Length == 1)
            {
                throw new ArgumentException($"Name cannot be empty");
            }

            string name = personInfo[0];
            decimal money = decimal.Parse(personInfo[1]);

            try
            {
                Person person = new Person(name, money);
                persons.Add(person);
            }
            catch (ArgumentException ex)
            {

                throw new ArgumentException($"{ex.Message}");
            }
        }
    }
}

