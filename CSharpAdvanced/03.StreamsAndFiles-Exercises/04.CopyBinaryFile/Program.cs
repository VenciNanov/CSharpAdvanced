using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var source = new FileStream(@"D:\CSharpAdvanced\03.StreamsAndFiles-Exercises\Resources\copyMe.png", FileMode.Open))
            {
                using (var destination = new FileStream(@"D:\CSharpAdvanced\03.StreamsAndFiles-Exercises\Resources\copyMe-Copy.png", FileMode.Create))
                {
                    while (true)
                    {
                        byte[] buffer = new byte[1024];
                        var readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes==0)
                        {
                            break;
                        }
                        destination.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
