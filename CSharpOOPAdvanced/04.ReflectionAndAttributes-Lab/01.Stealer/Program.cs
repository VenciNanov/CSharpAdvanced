using System;

namespace _01.Stealer
{
    class Program
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();

            string result = spy.CollectGettersAndSetters("Hacker");
            Console.WriteLine(result);
        }
    }
}
