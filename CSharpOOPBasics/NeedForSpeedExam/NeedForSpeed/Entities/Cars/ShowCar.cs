using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShowCar : Car
{
    public ShowCar(string brand, string model, int yearOfProduction, int horespower, int acceleration, int suspension, int duruability) : base(brand, model, yearOfProduction, horespower, acceleration, suspension, duruability)
    {
        this.Stars = 0;
    }

    public int Stars
    {
        get; set;
    }
    public override string ToString()
    {
        return base.ToString() + Environment.NewLine + this.Stars + " *";
    }

}