using StorageMaster.Entites.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Entites.Vehicles
{
    public abstract class Vehicle
    {
        private Stack<Product> trunk;

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new Stack<Product>();
        }

        public int Capacity { get; set; }

        public IReadOnlyCollection<Product> Trunk => trunk;

        public bool IsFull => Trunk.Sum(x => x.Weight) >= Capacity;

        public bool IsEmpty => Trunk.Count() == 0;

        public void LoadProduct(Product product)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }
            trunk.Push(product);
        }

        public Product Unload()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }

            var lastProduct = trunk.Last();

            trunk.Pop();

            return lastProduct;
        }
    }
}
