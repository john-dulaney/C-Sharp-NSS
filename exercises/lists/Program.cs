using System;
using System.Collections.Generic;
using System.Linq;

namespace lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> planetList = new List<string>() { "Mercury", "Mars" };
            planetList.Add("Jupiter");
            planetList.Add("Saturn");

            List<string> lastTwoPlanets = new List<string>
            {
                "Uranus",
                "Neptune"
            };

            // Kinda like the concat() method on JS arrays
            planetList.AddRange(lastTwoPlanets);

            planetList.Insert(1, "Venus");
            planetList.Insert(2, "Earth");

            planetList.Add("Pluto");

            // GetRange is the new slice()
            List<string> rockyPlanets = planetList.GetRange(0, 4);

            planetList.Remove("Pluto");

            foreach (string planet in planetList)
            {
                Console.WriteLine(planet);
            }

            List<Dictionary<string, List<string>>> spacecraft = new List<Dictionary<string, List<string>>>();

            // Create Mariner 10 info
            string mariner = "Mariner 10";
            List<string> marinerDestinations = new List<string> { "Mercury" };
            Dictionary<string, List<string>> mariner10 = new Dictionary<string, List<string>>();
            mariner10.Add(mariner, marinerDestinations);


            // Create Voyager 1 info
            string voyager1 = "Voyager 1";
            List<string> voyager1Destinations = new List<string>{
                "Jupiter", "Saturn"
            };
            Dictionary<string, List<string>> voyager1Dict = new Dictionary<string, List<string>>();
            voyager1Dict.Add(voyager1, voyager1Destinations);


            // Create Voyager 2 info
            string voyager2 = "Voyager 2";
            List<string> voyager2Destinations = new List<string>{
                "Jupiter", "Saturn", "Uranus", "Neptune"
            };
            Dictionary<string, List<string>> voyager2Dict = new Dictionary<string, List<string>>();
            voyager2Dict.Add(voyager2, voyager2Destinations);


            // Add all dictionaries to spacecraft collection
            // spacecraft.Add(mariner10);
            spacecraft.Add(voyager1Dict);
            spacecraft.Add(voyager2Dict);

            foreach (string planet in planetList)
            {
                Console.Write(planet);

                List<string> visitedPlanets = new List<string>();

                foreach (Dictionary<string, List<string>> craft in spacecraft)
                {
                    foreach (KeyValuePair<string, List<string>> item in craft)
                    {
                        if (item.Value.Contains(planet))
                        {
                            visitedPlanets.Add(item.Key);
                        }
                    }
                }

                visitedPlanets.ForEach(p => Console.Write($" {p}"));
                Console.WriteLine();
            }
        }
    }
}
