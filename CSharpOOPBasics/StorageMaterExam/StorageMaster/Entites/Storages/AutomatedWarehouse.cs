using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entites.Core.Factories;
using StorageMaster.Entites.Vehicles;

namespace StorageMaster.Entites.Storages
{
    public class AutomatedWarehouse : Storage
    {
        private static List<Vehicle> vehicles = new List<Vehicle>
        {
            new Truck()
        };

        

        public AutomatedWarehouse(string name) : base(name, 1, 2, vehicles)
        {
            
        }

    }
}
