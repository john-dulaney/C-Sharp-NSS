using System;
using System.Linq;
using System.Collections.Generic;

namespace tuples
{
    class Program
    {
        static void Main(string[] args)
        {

            ICollection<KeyValuePair<String, String>> openWith =
           new Dictionary<String, String>();
            List<(string product, double amount, int quantity)> transactions = new List<(string, double, int)>();
            // transactions.Add(new KeyValuePair<string>("Shoes", "37", "$6,251")),
            // transactions.Add(new KeyValuePair<string>("Shirts", "91", "$8,234")),
            // transactions.Add(new KeyValuePair<string>("Pants", "19", "$394")),
            // transactions.Add(new KeyValuePair<string>("Hats", "5", "$98")),
            // transactions.Add(new KeyValuePair<string>("Vest", "8", "$392"));

            foreach ((string product, double amount, int quantity) t in transactions)

            {
            //     int<(string)>
            // t.amount
            }
        }
    }
}
`


    // Console.WriteLine();
    //     foreach(KeyValuePair<string, string> element in openWith )
    //     {
    //         Console.WriteLine("{0}, {1}", element.Key, element.Value);
    //     }