using System;
using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Soldier, IPrivate, ILeutennantGeneral
{
    private decimal salary;
    private List<Private> privates;

    public LeutenantGeneral(int id, string firstName, string lastName,decimal salary) : base(id, firstName, lastName)
    {
        this.Salary = salary;
        this.privates = new List<Private>();
    }

    public IReadOnlyList<Private> Privates
    {
        get { return privates; }
    }


    public decimal Salary
    {
        get { return salary; }
        private set { salary = value; }
    }

    public void AddPrivate(Private @private)
    {
        this.privates.Add(@private);
    }

    public override string ToString()
    {
        var privates = Privates.Count == 0 ? string.Empty : $"{Environment.NewLine}" + string.Join($"{Environment.NewLine}", Privates);

        return $"{base.ToString()} Salary: {Salary:f2}{Environment.NewLine}" +
            $"Privates:{privates}";
    }


}
