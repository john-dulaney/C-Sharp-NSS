using System;
using System.Linq;
using System.Collections.Generic;

namespace lightning
{
    class Program
    {
        static void Main(string[] args)
        {
            // Add some more integers to the list
            // Iterate over the list and write only odd numbers to the console
            // The output should be on the same line.
            // Given the following list:

            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            numbers.Add(23);
            numbers.Add(44);
            numbers.Add(50);
            numbers.Add(45);

            foreach (int num in numbers)
            {
                if (num % 2 != 0)
                {
                    Console.Write(num + " ");
                }
            }

            // Given the following dictionary:

            Dictionary<string, int> transports = new Dictionary<string, int>() { { "bicycle", 2 } };
            transports.Add("tricycle", 3);
            transports.Add("car", 4);

            foreach(KeyValuePair<string, int> t in transports)
            {
                Console.Write($"A {t.Key} has {t.Value} wheels.");
            }
            // Add some more items to the dictionary.
            // Iterate over the dictionary and write 'A ____ has ____ wheels' to the console.
            // Each transport should be on a new line.

        }
    }
}
