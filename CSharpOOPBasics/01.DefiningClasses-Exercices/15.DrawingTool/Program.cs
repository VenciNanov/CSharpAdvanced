using System;

namespace _15.DrawingTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var shape = Console.ReadLine();
            var width = double.Parse(Console.ReadLine());

            double height = 0;

            switch (shape)
            {
                case "Square":
                    height = width;
                    break;
                case "Rectangle":
                    height = double.Parse(Console.ReadLine());
                    break;

                default:
                    break;
            }

            DrawTool draw = new DrawTool(width, height);
            draw.Draw();
        }
    }
}
