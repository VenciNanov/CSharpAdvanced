using StorageMaster.Entites.Core.Factories;
using StorageMaster.Entites.Products;
using StorageMaster.Entites.Storages;
using StorageMaster.Entites.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Entites.Core
{
    public class StorageMaster
    {
        private readonly StorageFactory storageFactory;
        private readonly ProductFactory productFactory;

        private Dictionary<string, Storage> storages;
        private Stack<Product> productPool;

        private Vehicle currentVehicle;

        public StorageMaster()
        {
            this.storageFactory = new StorageFactory();
            this.productFactory = new ProductFactory();
            this.storages = new Dictionary<string, Storage>();
            this.productPool = new Stack<Product>();
            this.currentVehicle = null;
        }

        public string AddProduct(string type, double price)
        {
            var product = productFactory.CreateProduct(type, price);

            productPool.Push(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            var storage = storageFactory.CreateStorage(type, name);
            storages[name] = storage;

            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var storage = storages[storageName];

            var vehicle = storage.GetVehicle(garageSlot);
            currentVehicle = vehicle;

            return $"Selected {vehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            var productsLoadedCount = 0;

            foreach (var product in productNames)
            {
                var isInStock = productPool
                    .Any(x => x.GetType().Name == product);

                if (!isInStock)
                {
                    throw new InvalidOperationException($"{product} is out of stock!");
                }

                var productToLoad = productPool
                    .FirstOrDefault(x => x.GetType().Name == product);

                currentVehicle.LoadProduct(productToLoad);

                productPool.Pop();

                productsLoadedCount++;

            }
            var productCount = productNames.Count();

            return $"Loaded {productsLoadedCount}/{productCount} products into {currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!storages.Any(x => x.Key == sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            if (!storages.Any(x => x.Key == destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }
            var vehicle = storages[sourceName]
                .GetVehicle(sourceGarageSlot);

            var destination = storages[destinationName];

            var destinationGarageSlot = storages[sourceName]
                 .SendVehicleTo(sourceGarageSlot, destination);

            return $"Sent {vehicle.GetType().Name} to {destination.Name} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var storage = storages[storageName];

            var vehicle = storages[storageName]
                .GetVehicle(garageSlot);

            var trunkCount = vehicle.Trunk.Count();

            var productsUnloaded = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {productsUnloaded}/{trunkCount} products at {storage.Name}";
        }

        public string GetStorageStatus(string storageName)
        {
            var storage = storages[storageName];

            var sb = new StringBuilder();

            var storageFilledCapacity = storage
                .Products
                .Sum(x => x.Weight);

            sb.Append($"Stock ({storageFilledCapacity}/{storage.Capacity}):");

            //Stock (2.7/10): [HardDrive (2), Gpu (1)]
            var productsDict = new Dictionary<Product, int>();

            foreach (var product in productPool)
            {
                if(!productsDict.ContainsKey(product))
                {
                    productsDict[product] = 0;
                }
                productsDict[product]++;
            }

            productsDict.OrderByDescending(x => x.Value);



            sb.AppendLine($" [{string.Join(", ", (productsDict.Select(x => $"{productsDict.Keys} ({productsDict.Values})")))}]");

            sb.Append("Garage: ");

            sb.AppendLine(string.Join(" | ", storage.Garage));

            //Garage: [Semi | Semi | Semi | Van | empty | empty | empty | empty | empty | empty]
            return sb.ToString().Trim();


            //var storage = storages[storageName];
            //var sortedStorage = storage
            //    .Products
            //    .GroupBy(x => x.GetType().Name)
            //    .OrderByDescending(x => x.Count()).
            //    OrderBy(x => x.GetType().Name);

            //var vehicleSorted = storage.Garage;
            //var sb = new StringBuilder();

            //var storageFilledCapacity = storage
            //    .Products
            //    .Sum(x => x.Weight);

            //sb.Append($"Stock ({storageFilledCapacity:f2}/{storage.Capacity}): ");


        }

        public string GetSummary()
        {
            var sortedStorages = storages
                .Values
                .OrderByDescending(x => x.Products
                .Sum(p => p.Price)).ToList();

            var sb = new StringBuilder();

            foreach (var storage in sortedStorages)
            {
                var storageWorth = storage.Products.Sum(x => x.Price);

                sb.AppendLine($"{storage.Name}:");
                sb.AppendLine($"Storage worth: ${storageWorth:f2}");
            }

            return sb.ToString().Trim();
        }


    }

}

