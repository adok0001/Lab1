using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            char option = '0';
            List<string> content = new List<string>();
            while (option != 'x')
            {
                Console.WriteLine("Hello World!!! My first C# App" +
                    "\nOptions" +
                    "\n---------------");
                Console.WriteLine("1 - Import Words From File" +
                    "\n2 - Bubble sort Words" +
                    "\n3 - LINQ/Lambda sort Words"+
                    "\n4 - Count the distinct words" +
                    "\n5 - Take the first 10 words"+
                    "\n6 - Get the number of words that start with 'j' and display the count" +
                    "\n7 - Get and display the number of words that end with 'd' and display the count" +
                    "\n8 - Get and display the number of words that are greater than 4 chars long, and display the count" +
                    "\n9 - Get and display the number of words that are less than 3 chars long and start with the letter 'a', and display the count" +
                    "\nx - Exit");
                Console.Write("Make a selection: ");
                option = Console.ReadLine()[0];
                Console.Clear();
                switch (option)
                {
                    case '1':
                        content = readFromFile(content);
                        break;
                    case '2':
                        DateTime start = DateTime.Now;
                        content = bubbleSort(content);
                        DateTime end = DateTime.Now;
                        Console.WriteLine("Time elapsed: {0} ms", (end - start).TotalMilliseconds);
                        break;
                    case '3':
                        start = DateTime.Now;
                        content.Sort();
                        end = DateTime.Now;
                        Console.WriteLine("Time elapsed: {0} ms", (end - start).TotalMilliseconds);
                        break;
                    case '4':
                        var distinctWords = content.Distinct();
                        Console.WriteLine("Number of distinct words: {0}",distinctWords.Count());
                        break;
                    case '5':
                        IEnumerable<string> temp = content.Take(10);
                        printContent(temp);
                        break;
                    case '6':
                        IEnumerable<string> jWords = content.Where(content => content.ToLower().StartsWith('j'));
                        printContent(jWords);
                        Console.WriteLine("Number of words that start with 'j': {0}", jWords.Count());
                        break;
                    case '7':
                        IEnumerable<string> dWords = content.Where(content => content.EndsWith('d'));
                        printContent(dWords);
                        Console.WriteLine("Number of words that end with 'd': {0}", dWords.Count());
                        break;
                    case '8':
                        IEnumerable<string> bigCharWords = content.Where(content => content.Length > 4);
                        printContent(bigCharWords);
                        Console.WriteLine("Number of words greater than 4 characters: {0}", bigCharWords.Count());
                        break;
                    case '9':
                        IEnumerable<string> smallCharWords = content.Where(content => content.ToLower().StartsWith('a') && content.Length < 3);
                        printContent(smallCharWords);
                        Console.WriteLine("Number of words less than 3 characters and start with 'a': {0}", smallCharWords.Count());
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
                Console.WriteLine("\n");

            }
        }

        /**
         * Method to read the contens of a file into list
         * @content List to save the contens of the file
         * @returns a list with contents of a file stored
         */
        static List<string> readFromFile(List<string> content)
        {
             static List<string> readFromFile(List<string> content)
        {
            try
            {
                content = File.ReadAllLines("../../../Words.txt").ToList();
                Console.WriteLine("Reading words complete");
                Console.WriteLine("Number of words found: {0}", content.Count);
            } catch (FileNotFoundException fe)
            {
                Console.WriteLine("Please check file path and try again");
            }
                return content;
        }
        }

        /**
         * Method to perform bubble sort on list
         * @content List to be sorted
         */
        static List<string> bubbleSort(List<string> content)
        {
            string temp;
            for(int i = 0; i < content.Count; i++)
            {
                for(int j = 0; j < content.Count; j++)
                {
                    if (content[j+1].CompareTo(content[j]) > 0)
                    {
                        temp = (string)content[j];
                        content[j] = content[j + 1];
                        content[j + 1] = temp;
                    }
                }
            }
            return content;
        }

        /**
         * Method to print out elements in passed IEnumerable
         * @content IEnumerable whose content is being printed out
         */
        static void printContent(IEnumerable<string> content)
        {
            foreach (string word in content)
            {
                Console.WriteLine(word);
            }
        }

        
    }
}
