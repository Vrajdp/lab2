using System;

namespace Lab2
{
    // Salaried class inheriting from Employee class
    public class Salaried : Employee
    {
        // Property for salary
        public double Salary { get; set; }

        // Constructor to initialize fields using the base class constructor
        public Salaried(string id, string name, string address, string phone, long sin, string dateOfBirth, string department, double salary)
            : base(id, name, address, phone, sin, dateOfBirth, department)
        {
            Salary = salary;
        }

        // Method to return the fixed salary for a salaried employee
        public double GetPay()
        {
            return Salary;
        }

        // Internal method (not implemented) to get the salary (consider removing or implementing as needed)
        internal int GetSalary()
        {
            throw new NotImplementedException();
        }
    }
}
