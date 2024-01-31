using System;

namespace Lab2
{
    // Wages class inheriting from Employee class
    public class Wages : Employee
    {
        // Fields for hours (private) and rate
        private int hours;

        public double Hours { get; set; }
        public double Rate { get; set; }

        // Constructor to initialize fields using the base class constructor
        public Wages(string id, string name, string address, string phone, long sin, string dateOfBirth, string department, double hours, double rate)
            : base(id, name, address, phone, sin, dateOfBirth, department)
        {
            Hours = hours;
            Rate = rate;
        }

        // Method to calculate and return the payment for an employee paid on an hourly basis
        public double GetPay()
        {
            double salary = 0;

            // Check if the hours worked are within regular working hours (40 hours)
            if (Hours <= 40)
                salary = Hours * Rate;  // Calculate regular pay
            else
            {
                int overtimeHours = (int)(hours - 40);
                salary = (overtimeHours * (Rate * 1.5)) + (40 * Rate);  // Calculate pay with overtime
            }

            return salary;
        }
    }
}
