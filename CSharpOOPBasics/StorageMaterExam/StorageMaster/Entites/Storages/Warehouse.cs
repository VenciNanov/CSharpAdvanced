using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entites.Vehicles;

namespace StorageMaster.Entites.Storages
{
    public class Warehouse : Storage
    {
        private static List<Vehicle> vehicles = new List<Vehicle>
        {
            new Semi(),
            new Semi(),
            new Semi()
        };

        public Warehouse(string name) : base(name, 10, 10, vehicles)
        {
        }
    }
}
