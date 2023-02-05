using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_inheritance.Entity
{
    internal class Wages : Employee
    {
        private double rate;
        private double hours;

        public Wages(string id, string name, double rate, double hours)
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
                double pay;
                
                if (hours > 40)
                {
                    pay = rate * 40;
                    double overHourPay = rate * 1.5 * (hours - 40);
                    pay += overHourPay;
                }

                else
                {
                    pay = rate * hours;
                }

                return pay;
            }
        }
    }
}
