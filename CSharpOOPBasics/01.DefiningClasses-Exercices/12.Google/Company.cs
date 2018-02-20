using System;
using System.Collections.Generic;
using System.Text;


public class Company
{
    private string name;
    private string department;
    private decimal salary;

    public Company(string name, string department, decimal salary)
    {
        this.name = name;
        this.department = department;
        this.salary = salary;
    }

    public override string ToString()
    {
        return $"{this.name} {this.department} {this.salary:F2}";
    }
}

