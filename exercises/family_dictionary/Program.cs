using System;
using System.Collections.Generic;

namespace family_dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, string>> myFamily = new Dictionary<string, Dictionary<string, string>>();

            myFamily.Add("sister", new Dictionary<string, string>(){
            {"name", "Allison J"},
            {"age", "32"}
            });

            myFamily.Add("sister", new Dictionary<string, string>(){
            {"name", "Allison L"},
            {"age", "39"}
            });

            myFamily.Add("father", new Dictionary<string, string>(){
            {"name", "Rick"},
            {"age", "70"}
            });

            myFamily.Add("mother", new Dictionary<string, string>(){
            {"name", "Sheridan"},
            {"age", "NaN"}
            });

            myFamily.Add("brother-in-law", new Dictionary<string, string>(){
            {"name", "Cody"},
            {"age", "34"}
            });

            // iterate over dictionary and print out details of each family member
            
            // this is refactored code, which is not dependend on the order of the inner dictionary of details. 
            foreach (KeyValuePair<string, Dictionary<string, string>> person in myFamily) 
            {
                string name = "";
                string age = ""; 
                
                foreach (KeyValuePair<string, string> details in person.Value) {
                    if (details.Key == "name") {
                        name = details.Value;
                    } else {
                        age = details.Value;
                    }
                }

                Console.WriteLine($"{name} is my {person.Key} and is {age} years old");
            }
        }
    }
}