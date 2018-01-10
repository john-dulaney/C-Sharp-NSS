using System;
using System.Collections.Generic;
using System.Linq;


namespace bangazon
{

    public class Sales : Department
    {

        public override void SetBudget(double budget)
        {
            // The sales department needs more money than most others
            this.Budget += budget + 100000.00;
        }
        double baseBudget = 75000.00;

        foreach(Department d in departments)
        {
            d.SetBudget(baseBudget);
            Console.WriteLine($"{d.toString()}");
        }




//ex 1

    private Dictionary<string, string> _policies = new Dictionary<string, string>();

    public Sales(string dept_name, string supervisor, int employees) : base(dept_name, supervisor, employees)
        {
    }

    public void AddPolicy(string title, string text)
    {
        _policies.Add(title, text);

        foreach (KeyValuePair<string, string> policy in _policies)
        {
            Console.WriteLine($"{policy.Value}");
        }
    }

    public string toString()
    {
        return $"{_name} {_supervisor} {_employee_count}";
    }
}

}