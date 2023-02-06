using Inheritance.Entities;
using System.Collections.Generic;

internal static class ProgramHelpers
{

    private static Wages FindLowestPaidEmployee(List<Employee> employees)
    {
        double lowestWagedPay = 0;
        Wages lowestPaidEmployee = null;

        foreach (Employee employee in employees)
        {
            if (employee is Wages wages)
            {
                double pay = wages.Pay;

                if (pay < lowestWagedPay)
                {
                    lowestWagedPay = pay;
                    lowestPaidEmployee = wages;
                }
            }
        }

        return lowestPaidEmployee;
    }

    
}