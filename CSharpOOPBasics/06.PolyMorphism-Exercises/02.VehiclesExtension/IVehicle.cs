using System;
using System.Collections.Generic;
using System.Text;

public interface IVehicle
{
    string Type { get; }
    double FuelQuantity { get; set; }
    double FuelConsumption { get; set; }
    double FuelTank { get; }
    bool AirConditioner { get; set; }

    void Drive(double distance);
    void Refill(double fuelAmount);
}
