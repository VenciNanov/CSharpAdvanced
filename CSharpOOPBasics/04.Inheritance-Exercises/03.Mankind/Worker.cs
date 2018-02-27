using System;
using System.Collections.Generic;
using System.Text;

public class Worker : Human
{
    private decimal weekSalary;
    private decimal hoursPerDay;
    private decimal salaryPerHour;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal hoursPerDay) : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.HoursPerDay = hoursPerDay;
        GetSalaryPerHour();
    }

    public decimal HoursPerDay
    {
        get { return this.hoursPerDay; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: workHoursPerDay");
            }

            this.hoursPerDay = value;
        }
    }
    public decimal WeekSalary
    {
        get { return this.weekSalary; }
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: weekSalary");
            }
            this.weekSalary = value;
        }
    }

    private decimal SalaryPerHour
    {
        get
        {
            return this.salaryPerHour;
        }
    }


    private void GetSalaryPerHour()
    {
        this.salaryPerHour = this.weekSalary / (this.hoursPerDay * 5);
    }

    public override string ToString()
    {
        return base.ToString() +
               $"Week Salary: {this.WeekSalary:F2}{Environment.NewLine}" +
               $"Hours per day: {this.HoursPerDay:F2}{Environment.NewLine}" +
               $"Salary per hour: {this.SalaryPerHour:F2}";
    }




}

