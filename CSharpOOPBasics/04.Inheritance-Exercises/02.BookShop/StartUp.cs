using System;

public class StartUp
{
    static void Main(string[] args)
    {
        try
        {
            var author = Console.ReadLine();
            var title = Console.ReadLine();
            var price = decimal.Parse(Console.ReadLine());

            Book book = new Book(author, title, price);
            GoldenEditionBook goldenBook = new GoldenEditionBook(author, title, price);

            Console.WriteLine(book + Environment.NewLine);
            Console.WriteLine(goldenBook);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }
}