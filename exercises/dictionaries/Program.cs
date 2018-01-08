using System;
using System.Collections.Generic;
using System.Linq;

namespace dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instructions
            // A block of publicly traded stock has a variety of attributes, we'll look at a few of them. A stock has a ticker symbol and a company name. Create a simple dictionary with ticker symbols and company names in the Main method.

            Dictionary<string, string> stocks = new Dictionary<string, string>();
            stocks.Add("GM", "General Motors");
            stocks.Add("CAT", "Caterpillar");
            stocks.Add("INTC", "Intel");
            stocks.Add("AAPL", "Apple");
            stocks.Add("MSFT", "Microsoft");

            // To find a value in a Dictionary, you can use square bracket notation much like JavaScript object key lookups.
            // string GM = stocks["GM"];

            // Create list of ValueTuples that represents stock purchases. Properties will be ticker, shares, price.
            List<(string ticker, int shares, double price)> purchases = new List<(string, int, double)>();

            purchases.Add((ticker: "GE", shares: 150, price: 23.21));
            purchases.Add((ticker: "GE", shares: 32, price: 17.87));
            purchases.Add((ticker: "GE", shares: 80, price: 19.02));

            purchases.Add((ticker: "CAT", shares: 823, price: 266.21));
            purchases.Add((ticker: "CAT", shares: 12, price: 11.27));
            purchases.Add((ticker: "CAT", shares: 40, price: 13.02));

            purchases.Add((ticker: "INTC", shares: 150, price: 29.01));
            purchases.Add((ticker: "INTC", shares: 32, price: 84.17));
            purchases.Add((ticker: "INTC", shares: 80, price: 18.82));

            purchases.Add((ticker: "AAPL", shares: 150, price: 94.81));
            purchases.Add((ticker: "AAPL", shares: 32, price: 92.87));
            purchases.Add((ticker: "AAPL", shares: 80, price: 33.93));

            purchases.Add((ticker: "MSFT", shares: 150, price: 67.20));
            purchases.Add((ticker: "MSFT", shares: 32, price: 329.98));
            purchases.Add((ticker: "MSFT", shares: 80, price: 23.82));


            // Create a total ownership report that computes the total value of each stock that you have purchased. This is the basic relational database join algorithm between two tables.

           
                // Define a new Dictionary to hold the aggregated purchase information.
                // - The key should be a string that is the full company name.
                // - The value will be the valuation of each stock (price*amount)

            Dictionary<string, int> stockTotals = new Dictionary<string, int>();
                
                    stockTotals.Add("General Electric", 35900);

            // Iterate over the purchases and update the valuation for each stock
            foreach ((string ticker, int shares, double price) purchase in purchases)
            {
                // Does the company name key already exist in the report dictionary?




                // If it does, update the total valuation






                // If not, add the new key and set its value




                
            }
        }
    }
}
