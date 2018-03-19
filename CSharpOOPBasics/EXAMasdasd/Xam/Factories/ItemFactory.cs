using Exam.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xam.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string itemName)
        {

            switch (itemName)
            {
                case "HealthPotion":
                    return new HealthPotion(5);

                case "PoisonPotion":
                    return new PoisonPotion(5);

                case "ArmorRepairKit":
                    return new ArmorRepairKit(10);
                default:
                    throw new ArgumentException($"Invalid item {itemName}!");
            }
        }
    }
}
