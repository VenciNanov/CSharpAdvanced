using System;
using System.Linq;

namespace _02.CubicsRube
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimension = int.Parse(Console.ReadLine());

            

            var allCells = dimension * dimension * dimension;

            var particlesSum = 0L;

            var line = Console.ReadLine();

            while (line!="Analyze")
            {
                var numbers = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();



                if (numbers[0] >= 0 && numbers[0] < dimension &&
                    numbers[1] >= 0 && numbers[1] < dimension && numbers[2] >= 0 && numbers[2] < dimension  && numbers[3] != 0)
                {
                    particlesSum += numbers[3];
                    allCells--;
                }
                line = Console.ReadLine();
                
            }
            Console.WriteLine(particlesSum);
            Console.WriteLine(allCells);
        }
    }
}
