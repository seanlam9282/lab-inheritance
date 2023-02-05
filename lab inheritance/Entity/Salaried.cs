using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_inheritance.Entity
{
    internal class Salaried : Employee
    {
        private double salary;

        public Salaried(string id, string name, double salary)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
        }

        public double Salary
        {
            get => salary; set => salary = value;
        }
        public double Pay
        {
            get => salary; set => salary = value;
        }
    }
}
