using Exam.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam.Models.Bags
{
    public abstract class Bag
    {
        private int capacity;
        private int load;
        private IReadOnlyList<Item> items;

        public Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
            this.Load = this.items.Sum(x => x.Weight);
        }


        public List<Item> Items
        {
            get { return items.ToList(); }
            set { items = value; }
        }

        public int Load
        {
            get { return load; }
            set { load = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            this.Items.Add(item);
        }

        public Item GetItem(string name)
        {
            Item item = items.SingleOrDefault(x => x.GetType().Name == name);

            if (this.Items.Count <= 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            else if (!this.Items.Any(x => x.GetType().Name == name))
            {
                throw new ArgumentException($"No item with {name} in bag!");
            }

            this.Items.Remove(item);
            return item;
        }

    }
}
