using StorageMaster.Entites.Products;
using StorageMaster.Entites.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Entites.Storages
{
    public abstract class Storage
    {
        private readonly List<Vehicle> garage;
        private readonly List<Product> products;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.garage = new List<Vehicle>(vehicles);
            this.products = new List<Product>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int GarageSlots { get; set; }

        public bool IsFull => products.Sum(x => x.Weight) >= Capacity;

        public virtual IReadOnlyCollection<Vehicle> Garage => garage.AsReadOnly();

        public IReadOnlyCollection<Product> Products => products.AsReadOnly();

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }
            if (garage[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            return garage[garageSlot];
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            var vehicle = GetVehicle(garageSlot);

            if (deliveryLocation.garage.Last() == null)
            {
                throw new InvalidOperationException("No room in garage!");
            }

            this.garage.Remove(vehicle);
            deliveryLocation.garage.Add(vehicle);

            return deliveryLocation.garage.IndexOf(vehicle);
        }

        public int UnloadVehicle(int garageSlot)
        {
            var vehicle = GetVehicle(garageSlot);

            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            var unloadedProductsCount = 0;

            foreach (var product in vehicle.Trunk.ToArray())
            {
                if (this.IsFull)
                {
                    break;
                }
                if (vehicle.IsEmpty)
                {
                    break;
                }
                var unloadedProduct = vehicle.Unload();
              this.products.Add(unloadedProduct);
                unloadedProductsCount++;
            }

            return unloadedProductsCount;

        }

        
    }
}
