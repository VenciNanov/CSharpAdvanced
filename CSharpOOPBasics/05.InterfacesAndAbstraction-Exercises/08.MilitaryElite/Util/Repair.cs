using System;
using System.Collections.Generic;
using System.Text;

public class Repair
    {
    private string partName;
    private int hoursWorked;

    public int HoursWorked
    {
        get { return hoursWorked; }
       private set { hoursWorked = value; }
    }

    public string PartName
    {
        get { return partName; }
        private set { partName = value; }
    }

    public Repair(string partName,int hoursWorked)
    {
        this.PartName = partName;
        this.HoursWorked = hoursWorked;
    }

    public override string ToString()
    {
        return $"  Part Name: {PartName} Hours Worked: {HoursWorked}";
    }

}

