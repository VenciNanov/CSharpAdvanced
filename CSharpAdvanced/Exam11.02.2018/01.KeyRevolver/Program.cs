using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {

            var bulletsStack = new Stack<int>();
            var locksQue = new Queue<int>();

            var bulletsPrice = int.Parse(Console.ReadLine());
            var gunBarrelSize = int.Parse(Console.ReadLine());

            var bullets = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();

            var locks = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var intelPrice = int.Parse(Console.ReadLine());

            var barrel = bullets.Count / gunBarrelSize;

            foreach (var bullet in bullets)
            {
                bulletsStack.Push(bullet);
            }
            foreach (var item in locks)
            {
                locksQue.Enqueue(item);
            }

            var counter = 0;

           while(true)
            { 
                if (bulletsStack.Peek() > locksQue.Peek())
                {
                    Console.WriteLine("Ping!");
                    bulletsStack.Pop();
                    var currLock = locksQue.Peek();
                    
                    
                }
                else if (bulletsStack.Peek() <= locksQue.Peek())
                {
                    Console.WriteLine("Bang!");
                    bulletsStack.Pop();
                    locksQue.Dequeue();
                }
                counter++;
                if (counter % gunBarrelSize == 0&&bulletsStack.Count>0)
                {
                    Console.WriteLine("Reloading!");
                }

                if (bulletsStack.Count <= 0 || locksQue.Count <= 0)
                {
                    break;
                }
            }

            if (locksQue.Count>0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQue.Count}");
            }
            else
            {
                var sum = intelPrice - (bulletsPrice * counter);
                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${sum}");
            }
            //Console.WriteLine(counter);
        }
    }
}
