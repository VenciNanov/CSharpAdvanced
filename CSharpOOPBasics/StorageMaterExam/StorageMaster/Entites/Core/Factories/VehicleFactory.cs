﻿using StorageMaster.Entites.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entites.Core.Factories
{
   public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type)
        {
            switch (type)
            {
                case "Van":
                    return new Van();
                case "Truck":
                    return new Truck();
                case "Semi":
                    return new Semi();
                default:
                    throw new InvalidOperationException("Invalid vehicle type!");
            }
        }
    }
}
