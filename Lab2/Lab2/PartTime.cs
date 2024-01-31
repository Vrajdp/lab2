using System;
using System.Diagnostics.Eventing.Reader;

namespace Lab2
{
    // PartTime class inheriting from Employee class
    public class PartTime : Employee
    {
        // Properties for hours and rate
        public double Hours { get; set; }
        public double Rate { get; set; }

        // Constructor to initialize fields using the base class constructor
        public PartTime(string id, string name, string address, string phone, long sin, string dateOfBirth, string department, double hours, double rate)
            : base(id, name, address, phone, sin, dateOfBirth, department)
        {
            Hours = hours;
            Rate = rate;
        }

        // Method to calculate and return the payment for a part-time employee
        public double GetPay()
        {
            double salary = 0;

            // Check if the hours worked are within regular working hours (40 hours)
            if (Hours <= 40)
                salary = Hours * Rate;  // Calculate regular pay
            else
                salary = 40 * Rate + (Hours - 40) * (Rate * 1.5);  // Calculate pay with overtime

            return salary;
        }
    }
}
