using System;
using System.Collections.Generic;
using System.Text;

public class Engineer:SpecialisedSoldier
{
    private List<Repair> repairs;

    public Engineer(int id, string firstName, string lastName, decimal salary, string corp) : base(id, firstName, lastName, salary, corp)
    {
        this.repairs = new List<Repair>();
    }

    public List<Repair> Repairs
    {
        get { return repairs; }
       
    }

    public void AddRepair(Repair repair)
    {
        this.repairs.Add(repair);
    }

    public override string ToString()
    {
        string missions = Repairs.Count == 0 ? string.Empty : $"{Environment.NewLine}" + string.Join($"{Environment.NewLine}", Repairs);

        return $"{base.ToString()}{Environment.NewLine}" +
            $"Repairs:{missions}";
    }


}
