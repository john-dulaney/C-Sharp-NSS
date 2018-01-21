using System;
using System.Collections.Generic;
using System.Linq;

namespace dictionaries {
    class Program {
        static void Main (string[] args) {
            //Add some stocks and their full names to dictionary 'stocks'
            Dictionary<string, string> stocks = new Dictionary<string, string> ();
            stocks.Add ("GM", "General Motors");
            stocks.Add ("CAT", "Caterpillar");
            stocks.Add ("INTC", "Intel");
            stocks.Add ("AAPL", "Apple");
            stocks.Add ("MSFT", "Microsoft");

            //create a dictionary that stores symbol/shares/price
            List<(string ticker, int shares, double price)> purchases = new List<(string, int, double)> ();
            purchases.Add ((ticker: "GE", shares : 150, price : 23.21));
            purchases.Add ((ticker: "CAT", shares : 823, price : 266.21));
            purchases.Add ((ticker: "INTC", shares : 123, price : 29.01));
            purchases.Add ((ticker: "AAPL", shares : 5, price : 94.81));
            purchases.Add ((ticker: "MSFT", shares : 82, price : 67.20));

            // Define a new Dictionary to hold the aggregated purchase information.
            // - The key should be a string that is the full company name.
            // - The value will be the valuation of each stock (price*amount)

            Dictionary<string, double> stockPrice = new Dictionary<string, double> ();

            foreach ((string, int, double) stock in purchases) {
                double heldCap = stock.Item2 * stock.Item3;

                foreach ((string ticker, int shares, double price) purchase in purchases) {
                    string stockName = stocks[purchase.ticker];
                    if (stockPrice.ContainsKey (stockName)) {
                        stockPrice[stockName] += purchase.shares * purchase.price;
                    } else {
                        stockPrice.Add (stockName, (purchase.shares * purchase.price));
                    }
                }
                foreach (KeyValuePair<string, double> ownedStock in stockPrice) {
                    Console.WriteLine ($"{ownedStock.Key}: ${ownedStock.Value}");
                }
            }
        }
    }
}