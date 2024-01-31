using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab2
{
    class Program
    {
        // Read data from the input file and fill into the list of employees
        static List<Employee> LoadEmployeesListFromFile(string filePath)
        {
            List<Employee> employees = new List<Employee>();
            string[] fileLines = File.ReadAllLines(filePath);

            foreach (string line in fileLines)
            {
                if (line != "")
                {
                    string[] fields = line.Split(':');
                    string id = fields[0];
                    char id_firstChar = id[0];
                    switch (id_firstChar)
                    {
                        case '0':
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                            employees.Add(new Salaried(fields[0], fields[1], fields[2], fields[3],
                                                       long.Parse(fields[4]), fields[5],
                                                       fields[6], Double.Parse(fields[7])));
                            break;
                        // TODO: Add cases for other types of employees
                        case '5':
                        case '6':
                        case '7':
                            employees.Add(new Wages(fields[0], fields[1], fields[2], fields[3],
                                                     long.Parse(fields[4]), fields[5],
                                                     fields[6], Double.Parse(fields[7]), Double.Parse(fields[8])));
                            break;
                        case '8':
                        case '9':
                            employees.Add(new PartTime(fields[0], fields[1], fields[2], fields[3],
                                                       long.Parse(fields[4]), fields[5],
                                                       fields[6], Double.Parse(fields[7]), Double.Parse(fields[8])));
                            break;
                    }
                }
            }
            return employees;
        }


        // Returns the average pay of all employees.
        static double AveragePay(List<Employee> employees)
        {

            double totalPay = 0;
            foreach (Employee emp in employees)
            {
                if (emp is Salaried)
                {
                    totalPay += ((Salaried)emp).GetPay();
                }
                // TODO: Implement the necessary code to calculate the average for all employees
                else if (emp is Wages wagesEmp)
                {
                    totalPay += wagesEmp.GetPay();
                }
                else if (emp is PartTime partTimeEmp)
                {
                    totalPay += partTimeEmp.GetPay();
                }
            }
            return Math.Round(totalPay / employees.Count(), 2);
        }
        
		// Returns the Wages employee with the highest pay.		 
        static Wages HighestPayWagesEmployee(List<Employee> employees)
        {
            double highestPay = 0;
            Wages highestPayEmp = null;
            for (int i = 0; i < employees.Count(); i++)
            {
                Employee emp = employees[i];
                if (emp is Wages)
                {
                    Wages wageEmp = (Wages)emp;
                    if (wageEmp.GetPay() > highestPay)
                    {
                        highestPay = wageEmp.GetPay();
                        highestPayEmp = wageEmp;
                    }
                }
            }
            return highestPayEmp;
        }

        // Returns the Salaried employee with the lowest pay.		 
        static Salaried LowestPaySalariedEmployee(List<Employee> employees)
        {
            Salaried lowestPayEmp = null;
            // TODO: Implement the necessary code to get the employee with lowest payment
            double lowestSalary = double.MaxValue; 

            foreach (var employee in employees)
            {
                if (employee is Salaried salariedEmployee) 
                {
                    double salary = salariedEmployee.GetPay(); 

                    if (salary < lowestSalary)
                    {
                        lowestSalary = salary;
                        lowestPayEmp = salariedEmployee;
                    }
                }
            }


            return lowestPayEmp;
        }
        
		// Returns the percentage of Salaried employees.
        static double PercentageOfSalaried(List<Employee> employees)
        {
            int count = 0;
            foreach (Employee emp in employees)
            {
                if (emp is Salaried)
                {
                    count++;
                }
            }
            return Math.Round((double)count / employees.Count() * 100, 2);
        }

		 // Returns the percentage of Wages employees.
        static double PercentageOfWages(List<Employee> employees)
        {
            // TODO: Implement the necessary code to calculate percentage of the wages employees
            // ...........................................

            if (employees == null || employees.Count == 0)
            {
                return 0.0; 
            }

            int wagesEmployeeCount = employees.Count(emp => emp is Wages);
            double totalEmployees = employees.Count;
            double percentage = (wagesEmployeeCount / totalEmployees) * 100;

            return Math.Round(percentage, 2);



        }
        
		// Returns the percentage of PartTime employees.
        static double PercentageOfPartTime(List<Employee> employees)
        {
            // TODO: Implement the necessary code to calculate percentage of the PartTime employees
            // ...........................................

            if (employees == null || employees.Count == 0)
            {
                return 0.0; // Return 0 if the list is null or empty
            }

            int partTimeEmployeeCount = employees.Count(emp => emp is PartTime);
            double totalEmployees = employees.Count;
            double percentage = (partTimeEmployeeCount / totalEmployees) * 100;

            return Math.Round(percentage, 2);
        }

        static void Main(string[] args)
        {
            string inputFilePath = @"../../data/employees.txt";
            List<Employee> employees = LoadEmployeesListFromFile(inputFilePath);

            Console.WriteLine($"The average pay for all employees is: {AveragePay(employees)}");

            Wages wage_emp = HighestPayWagesEmployee(employees);
            Console.WriteLine($"The Wages employee with the highest pay is: {wage_emp} \n\twith salary of {wage_emp.GetPay()}");

            Salaried salaried_emp = LowestPaySalariedEmployee(employees);
            Console.WriteLine($"The Salaried employee with the lowest pay is: {salaried_emp} \n\twith salary of {salaried_emp.GetPay()}");

            Console.WriteLine($"Percentage of Salaried employees is: {PercentageOfSalaried(employees)} %");
            Console.WriteLine($"Percentage of Wages employees is: {PercentageOfWages(employees)} %");
            Console.WriteLine($"Percentage of Part Time employees is: {PercentageOfPartTime(employees)}%");

            Console.ReadKey();
            ///
        }
    }
}
