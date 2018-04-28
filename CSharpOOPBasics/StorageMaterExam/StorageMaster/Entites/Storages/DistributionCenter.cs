using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entites.Vehicles;

namespace StorageMaster.Entites.Storages
{
    public class DistributionCenter : Storage
    {
        private static List<Vehicle> vehicles = new List<Vehicle>
        {
            new Van(),
            new Van(),
            new Van()
        };
        public DistributionCenter(string name) : base(name, 2, 5, vehicles)
        {
        }
    }
}
