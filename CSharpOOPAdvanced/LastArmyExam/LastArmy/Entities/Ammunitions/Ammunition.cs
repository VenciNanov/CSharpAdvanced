using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 public abstract class Ammunition : IAmmunition
    {
        private const int WearLvlMultiplier = 100;

        public Ammunition(string name,double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.WearLevel = this.Weight * WearLvlMultiplier;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public double WearLevel { get; private set; }

        public void DecreaseWearLevel(double wearAmount)
        {
            this.WearLevel -= wearAmount;
        }
    }
