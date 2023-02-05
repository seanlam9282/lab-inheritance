using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_inheritance.Entity
{
    internal class PartTime : Employee
    {
        private double rate;
        private double hours;

        public PartTime(string id, string name, double rate, double hours)
        {
            this.id = id;
            this.name = name;
            this.rate = rate;
            this.hours = hours;
        }

        public double Rate
        {
            get => rate; set => rate = value;
        }
        public double Hours
        {
            get => hours; set => hours = value;
        }
        public double Pay
        {
            get
            {
                double pay = rate * hours;
                return pay;
            }
        }
    }
}
