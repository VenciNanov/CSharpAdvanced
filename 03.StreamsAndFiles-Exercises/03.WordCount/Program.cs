using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var wordsReader = new StreamReader(@"D:\CSharpAdvanced\03.StreamsAndFiles-Exercises\Resources\words.txt"))
            {
                using (var textReader = new StreamReader(@"D:\CSharpAdvanced\03.StreamsAndFiles - Exercises\Resources\text.txt"))
                {
                    using (var writer = new StreamWriter(@"D:\CSharpAdvanced\03.StreamsAndFiles-Exercises\Resources\result.txt"))
                    {
                        //Words Reader
                        Dictionary<string, int> wordCount = WordsReader(wordsReader);

                        //Text Reader
                        TextReader(textReader, wordCount);

                        //Printer
                        wordCount = Printer(writer, wordCount);

                    }
                }
            }
        }

        private static Dictionary<string, int> Printer(StreamWriter writer, Dictionary<string, int> wordCount)
        {
            wordCount = wordCount.OrderByDescending(w => w.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (KeyValuePair<string, int> kvp in wordCount)
            {
                writer.WriteLine($"{kvp.Key}-{kvp.Value}");
            }

            return wordCount;
        }

        private static void TextReader(StreamReader textReader, Dictionary<string, int> wordCount)
        {
            string line = null;

            while ((line = textReader.ReadLine()) != null)
            {
                foreach (var word in line.ToLower().Split(new[] { ' ', '.', ',', '-', '?', '!' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (wordCount.ContainsKey(word))
                    {
                        wordCount[word]++;
                    }
                }
            }
        }

        private static Dictionary<string, int> WordsReader(StreamReader wordsReader)
        {
            var wordCount = new Dictionary<string, int>();

            var words = wordsReader.ReadLine().ToLower();

            while (words != null)
            {
                wordCount[words] = 0;

                words = wordsReader.ReadLine();
            }

            return wordCount;
        }
    }
}

