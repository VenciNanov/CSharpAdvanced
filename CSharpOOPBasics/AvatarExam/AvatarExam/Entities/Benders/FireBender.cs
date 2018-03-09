using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 public class FireBender : Bender
    {
        private double heatAggression;

        public FireBender(string name, int power,double heatAggression) : base(name, power)
        {
            this.heatAggression = heatAggression;
        }

    public override double GetPower()
    {
        return this.heatAggression * this.Power;
    }
}

