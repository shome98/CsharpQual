using CSharpQualifier30thjan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace CSharpQualifier30thjan
{
    internal class IncomeTax
    {


        public class Employee
        {
            public string EmployeeId { get; set; }
            public double Salary { get; set; }

        }
        public class EmployeeUtility : Employee
        {
            public bool ValidateEmployeeId()
            {
                if (EmployeeId.Length == 4)
                {
                    string pattern = @"^[A-Z]\d{3}$";
                    if (Regex.IsMatch(EmployeeId, pattern))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            public double calculateTaxAmount()
            {
                double tax = 0.0;
                if (Salary <= 20000)
                {
                    tax = 0;
                }
                else if (Salary > 20000 && Salary <= 50000)
                {
                    tax = ((Salary - 20000) * 0.10);
                }
                else if (Salary > 50000 && Salary < 100000)
                {
                    tax = ((30000) * 0.10) + ((Salary - 50000) * 0.20);
                }
                else
                {
                    tax = ((30000) * 0.10) + ((50000) * 0.20) + ((Salary - 100000) * 0.30);
                }
                return tax;
            }


        }

        public class Program
        {
            public static void Main(string[] args)
            {
                EmployeeUtility eu = new EmployeeUtility();

                Console.WriteLine("Enter the Employee Id");
                eu.EmployeeId = Console.ReadLine();

                if (eu.ValidateEmployeeId())
                {
                    Console.WriteLine("Enter the Salary");
                    eu.Salary = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Total Tax amount is :" + eu.calculateTaxAmount());
                }
                else
                {
                    Console.WriteLine("Invalid Employee Id");
                }

            }
        }
    }
}