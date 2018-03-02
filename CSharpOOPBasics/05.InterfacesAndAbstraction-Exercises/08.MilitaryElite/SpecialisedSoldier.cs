using System;
using System.Collections.Generic;
using System.Text;

public class SpecialisedSoldier : Soldier, IPrivate
{
    private decimal salary;
    private string corp;

    public SpecialisedSoldier(int id, string firstName, string lastName,decimal salary,string corp) : base(id, firstName, lastName)
    {
        this.Salary = salary;
        this.Corp = corp;
    }

    public string Corp
    {
        get { return this.corp; }
        private set
        {
            if (value != "Airforces" && value != "Marines")
            {
                throw new ArgumentException();
            }
            this.corp = value;
        }
    }


    public decimal Salary
    {
        get { return this.salary; }
        private set { this.salary = value; }
    }

    public override string ToString()
    {
        return $"{base.ToString()} Salary: {Salary:f2}{Environment.NewLine}" +
            $"Corps: {Corp}";
    }

}
