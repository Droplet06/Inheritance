using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Entities
{
    internal class Salaries : Employee
    {
        private double salary;

        public double Salary
        {
            get
            {
                return salary;
            }
        }

        public override double Pay
        {
            get
            {
                return salary;
            }
        }

        public Salaries(string id, string name, double salary)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
        }
    }
}

