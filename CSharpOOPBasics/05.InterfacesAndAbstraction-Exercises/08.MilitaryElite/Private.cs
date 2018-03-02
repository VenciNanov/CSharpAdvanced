public class Private:Soldier,IPrivate
{
        private decimal salary;

    public Private(int id, string firstName, string lastName,decimal salary) : base(id, firstName, lastName)
    {
        this.Salary = salary;
    }

    public decimal Salary
    {
        get { return this.salary; }
        private set { this.salary = value; }
    }

    public override string ToString()
    {
        return $"{base.ToString()} Salary: {Salary:f2}";
    }
}