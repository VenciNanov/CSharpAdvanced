using System;
using System.Collections.Generic;
using System.IO;

namespace _05.SlicingFile
{
    class Program
    {
        private static List<string> files = new List<string>();
        static void Main(string[] args)
        {
            var source = @"D:\CSharpAdvanced\03.StreamsAndFiles-Exercises\Resources\sliceMe.mp4";

            var destination = "";
            var parts = int.Parse(Console.ReadLine());

            Slice(source, destination, parts);

            var outputFileName = destination + "assembled.mp4";

            Assemble(files, outputFileName);
        }

        private static void Assemble(List<string> files, string outputFileName)
        {
            using (var desination = new FileStream(outputFileName,FileMode.OpenOrCreate))
            {
                for (int i = 0; i < files.Count; i++)
                {
                    using (var source = new FileStream(files[i],FileMode.Open))
                    {
                        byte[] buffer = new byte[4069];
                        while (true)
                        {
                            var readbytes = source.Read(buffer, 0, buffer.Length);
                            if (readbytes==0)
                            {
                                break;
                            }
                            desination.Write(buffer, 0, readbytes);
                        }
                    }
                }
            }
        }

        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                var fileLength = (int)(source.Length / parts);
                var buffer = new byte[fileLength];

                var dotIndex = sourceFile.LastIndexOf('.');
                var fileExtension = sourceFile.Substring(dotIndex);

                for (int i = 0; i < parts; i++)
                {
                    var file = destinationDirectory + "Part-" + i + fileExtension;
                    using (var destination= new FileStream(file,FileMode.CreateNew))
                    {
                        var readBytes = source.Read(buffer, 0, fileLength);
                        if (readBytes==0)
                        {
                            break;
                        }

                        destination.Write(buffer, 0, readBytes);
                        files.Add(file);
                    }
                }
            }
        }
    }
}
