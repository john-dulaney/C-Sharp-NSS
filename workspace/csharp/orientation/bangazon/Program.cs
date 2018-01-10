using System;
using System.Collections.Generic;
using System.Linq;

namespace bangazon
{
    public class Program
    {
        public static void Main()
        {
            List<Department> departments = new List<Department>();

            // Create some instances
            HumanResources hr = new HumanResources("HR", "George Carlin", 2);
            ITDepartment it = new ITDepartment("it", "Richard Pryor", 3);
            Sales sales = new Sales("Sales", "Dave Chapelle", 4);

            // Add derived departments to the list
            departments.Add(hr);
            departments.Add(it);
            departments.Add(sales);

            // Iterate over all items in the list and output a string 
            // representation of the class
            foreach (Department d in departments)
            {
                Console.WriteLine($"{d.toString()}");
            }
        }
    }
}