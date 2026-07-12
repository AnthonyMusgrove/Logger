using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerDemo
{
    public class LoremIpsumGenerator
    {
        private static readonly string[] Words = new[]
        {
        "lorem", "ipsum", "dolor", "sit", "amet", "consectetur", "adipiscing", "elit",
        "sed", "do", "eiusmod", "tempor", "incididunt", "ut", "labore", "et", "dolore",
        "magna", "aliqua", "ut", "enim", "ad", "minim", "veniam", "quis", "nostrud",
        "exercitation", "ullamco", "laboris", "nisi", "ut", "aliquip", "ex", "ea",
        "commodo", "consequat", "duis", "aute", "irure", "dolor", "in", "reprehenderit",
        "in", "voluptate", "velit", "esse", "cillum", "dolore", "eu", "fugiat", "nulla",
        "pariatur", "excepteur", "sint", "occaecat", "cupidatat", "non", "proident",
        "sunt", "in", "culpa", "qui", "officia", "deserunt", "mollit", "anim", "id", "est", "laborum"
    };

        public static string GenerateWords(int wordCount)
        {
            Random rand = new Random();

            // Randomly select words and join them with spaces
            var selectedWords = Enumerable.Range(0, wordCount)
                .Select(_ => Words[rand.Next(Words.Length)]);

            return string.Join(" ", selectedWords);
        }
    }
}
