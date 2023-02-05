using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_inheritance.Entity;
using System.IO.Ports;
using System.Globalization;

namespace lab_inheritance
{
    internal class Program
    {
        /// <summary>
        /// Method of average weekly pay calculation
        /// </summary>
        /// <param name="employees"></param>
        /// <returns></returns>
        private static double CalcAverageWeeklyPay(List<Employee> employees)
        {
            double weeklyPaySum = 0;

            foreach (Employee employee in employees)
            {
                if (employee is Salaried salaried)
                {
                    double pay = salaried.Pay;
                    weeklyPaySum += pay;
                }

                else if (employee is Wages waged)
                {
                    double pay = waged.Pay;
                    weeklyPaySum += pay;
                }

                else if (employee is PartTime partTime)
                {
                    double pay = partTime.Pay;
                    weeklyPaySum += pay;
                }
            }
            double averageWeeklyPay = weeklyPaySum / employees.Count;
            return averageWeeklyPay;
        }

        /// <summary>
        /// Method of highest wage pay finding
        /// </summary>
        /// <param name="employees"></param>
        /// <returns></returns>
        private static Wages HighestWagePay(List<Employee> employees)
        {
            double highestWagePay = 0;
            Wages highestWageEmployee = null;

            foreach (Employee employee in employees)
            {
                if (employee is Wages waged)
                {
                    double pay = waged.Pay;

                    if (pay > highestWagePay)
                    {
                        highestWagePay = pay;
                        highestWageEmployee = waged;
                    }
                }
            }
            return highestWageEmployee;
        }

        /// <summary>
        /// Method of lowest salary pay finding
        /// </summary>
        /// <param name="employees"></param>
        /// <returns></returns>
        private static Salaried LowestSalaryPay(List<Employee> employees)
        {
            double lowestSalaryPay = double.MaxValue;
            Salaried lowestSalaryEmployee = null;

            foreach (Employee employee in employees)
            {
                if (employee is Salaried salaried)
                {
                    double pay = salaried.Pay;

                    if (pay < lowestSalaryPay)
                    {
                        lowestSalaryPay = pay;
                        lowestSalaryEmployee = salaried;
                    }
                }
            }
            return lowestSalaryEmployee;
        }

        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string path = "employees.txt";

            string[] lines = File.ReadAllLines(path);

            List<Employee> employees = new List<Employee>();

            foreach (string line in lines)
            {
                string[] parts = line.Split(':');

                string id = parts[0];
                string name = parts[1];
                string address = parts[2];
                string phone = parts[3];
                long sin = Convert.ToInt64(parts[4]);
                string birthdate = parts[5];
                string department = parts[6];
                
                string firstDigit = id.Substring(0, 1);
                if (firstDigit == "0" || firstDigit == "1" || firstDigit == "2" || firstDigit == "3" || firstDigit == "4") 
                {
                    double salary = double.Parse(parts[7]);
                    Salaried salaried = new Salaried(id, name, salary);
                    employees.Add(salaried);
                }

                else if (firstDigit == "5" || firstDigit == "6" || firstDigit == "7")
                {
                    double rate = double.Parse(parts[7]);
                    double hours = double.Parse(parts[8]);
                    Wages waged = new Wages(id, name, rate, hours);
                    employees.Add(waged);
                }

                else if (firstDigit == "8" || firstDigit == "9")
                {
                    double rate = double.Parse(parts[7]);
                    double hours = double.Parse(parts[8]);
                    PartTime partTime = new PartTime(id, name, rate, hours);
                    employees.Add(partTime);
                }
            }
            
            // Question 4b
            Console.WriteLine("Average weekly pay: " + CalcAverageWeeklyPay(employees).ToString("C", CultureInfo.CurrentCulture) + "\n");

            // Question 4c
            Console.WriteLine("The highest wage employee: " + HighestWagePay(employees).Name);
            Console.WriteLine("The highest wage pay: " + HighestWagePay(employees).Pay.ToString("C", CultureInfo.CurrentCulture) + "\n");

            // Question 4d
            Console.WriteLine("The lowest salary employee: " + LowestSalaryPay(employees).Name);
            Console.WriteLine("The lowest salary pay: " + LowestSalaryPay(employees).Pay.ToString("C", CultureInfo.CurrentCulture) + "\n");

            // Question 4e
            double salaryEmployee = 0;
            double wageEmployee = 0;
            double partTimeEmployee = 0;
            foreach (Employee employee in employees)
            {
                
                if (employee is Salaried salaried)
                {
                    salaryEmployee += 1;
                }

                else if (employee is Wages waged)
                {
                    wageEmployee += 1;
                }

                else if (employee is PartTime partTime)
                {
                    partTimeEmployee += 1;
                }
            }
            string salaryPercent = string.Format("{0:p2}", salaryEmployee / employees.Count);
            string wagePercent = string.Format("{0:p2}", wageEmployee / employees.Count);
            string partTimePercent = string.Format("{0:p2}", partTimeEmployee / employees.Count);
            Console.WriteLine("Salary Employee: {0}/{1} ({2})", salaryEmployee, employees.Count, salaryPercent);
            Console.WriteLine("Wage Employee: {0}/{1} ({2})", wageEmployee, employees.Count, wagePercent);
            Console.WriteLine("Part Time Employee: {0}/{1} ({2})\n", partTimeEmployee, employees.Count, partTimePercent);
        }
    }
}
