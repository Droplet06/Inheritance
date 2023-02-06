using Inheritance.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Inheritance
{
    internal class Program
    {
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

                string firstDigit;

                firstDigit = id.Substring(0, 1);

                int firstDigitNum = int.Parse(firstDigit);

                if (firstDigitNum >= 0 && firstDigitNum <= 4)
                {
                    double salary = double.Parse(parts[7]);

                    Salaries salaries;

                    salaries = new Salaries(id, name, salary);

                    employees.Add(salaries);
                }
                else if (firstDigitNum >= 5 && firstDigitNum <= 7)
                {
                    double rate = double.Parse(parts[7]);
                    double hours = double.Parse(parts[8]);

                    Wages wages = new Wages(id, name, rate, hours);
                    employees.Add(wages);
                }
                else if (firstDigitNum >= 8 && firstDigitNum <= 9)
                {
                    double rate = double.Parse(parts[7]);
                    double hours = double.Parse(parts[8]);

                    PartTime partTime = new PartTime(id, name, rate, hours);
                    employees.Add(partTime);
                }
            }


            double averageWeeklyPay = CalAveWeeklyPay(employees);

            Console.WriteLine(string.Format("Average weekly pay: {0:C2}", averageWeeklyPay));

            Employee highestPaidEmployee = FindHighestPaidEmployee(employees);

            double highestWagedPay = highestPaidEmployee.Pay;


            Console.WriteLine("Highest pay: " + highestWagedPay.ToString("C2"));
            Console.WriteLine("Highest waged employee: " + highestPaidEmployee.Name);

            Employee lowestPaidEmployee = FindlowestPaidEmployee(employees);

            double lowestWagedPay = lowestPaidEmployee.Pay;

            Console.WriteLine("Lowest pay: " + lowestWagedPay.ToString("C2"));
            Console.WriteLine("est waged employee: " + lowestPaidEmployee.Name);





        }

        private static double CalAveWeeklyPay(List<Employee> employees)
        {
            double weeklyPaySum = 0;

            foreach (Employee employee in employees)
            {
                if (employee is PartTime partTime)
                {
                    double pay = partTime.Pay;
                    weeklyPaySum += pay;
                }
                else if (employee is Wages wages)
                {
                    double pay = wages.Pay;

                    weeklyPaySum += pay;
                }
                else if (employee is Salaries salaries)
                {
                    double pay = salaries.Pay;

                    weeklyPaySum += pay;
                }
            }

            double avarageWeeklyPay = weeklyPaySum / employees.Count;

            return avarageWeeklyPay;
        }

        private static Wages FindHighestPaidEmployee(List<Employee> employees)
        {
            double highestWagedPay = 0;
            Wages highestPaidEmployee = null;

            foreach (Employee employee in employees)
            {
                if (employee is Wages wages)
                {
                    double pay = wages.Pay;

                    if (pay > highestWagedPay)
                    {
                        highestWagedPay = pay;
                        highestPaidEmployee = wages;
                    }
                }
            }

            return highestPaidEmployee;
        }

        private static Wages FindlowestPaidEmployee(List<Employee> employees)
        {

            double lowestWagedPay = double.MaxValue;

            Wages lowestWagedEmployee = null;

            foreach (Employee employee in employees)
            {

                if (employee is Wages wages)
                {
                    double pay = wages.Pay;

                    if (pay > lowestWagedPay)
                    {
                        lowestWagedPay = pay;
                        lowestWagedEmployee = wages;
                    }
                }
            }

            return lowestWagedEmployee;
        }

     

    }
}
