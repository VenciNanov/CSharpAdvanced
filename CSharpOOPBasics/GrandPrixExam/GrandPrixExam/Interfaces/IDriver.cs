using System;
using System.Collections.Generic;
using System.Text;


public interface IDriver
{
    string Name { get; set; }
    double TotalTime { get; set; }
    Car Car { get; set; }
    double FuelConsumptionPerKm { get; set; }
   // double Speed { get; set; }

}