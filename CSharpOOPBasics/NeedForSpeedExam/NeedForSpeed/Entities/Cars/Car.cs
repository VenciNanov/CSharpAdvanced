using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Car
{

    protected Car(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.Horespower = horsepower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Duruability = durability;
    }

    public string Brand { get; private set; }
    public string Model { get; private set; }
    public int YearOfProduction { get; private set; }
    public int Horespower { get; set; }
    public int Acceleration { get; private set; }
    public int Suspension { get; set; }
    public int Duruability { get; set; }


    public int GetOverallPerformance()
    {
        return (this.Horespower / this.Acceleration) + (this.Suspension + this.Duruability);
    }

    public int GetEnginePerformance()
    {
        return (this.Horespower / this.Acceleration);
    }

    public int GetSuspensionPerformance()
    {
        return (this.Suspension + this.Duruability);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}")
            .AppendLine($"{this.Horespower} HP, 100 m/h in {this.Acceleration} s")
            .AppendLine($"{this.Suspension} Suspension force, {this.Duruability} Durability");

        return sb.ToString().Trim();
    }
}