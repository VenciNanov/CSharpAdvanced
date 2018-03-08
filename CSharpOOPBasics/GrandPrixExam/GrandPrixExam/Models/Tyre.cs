using System;
using System.Collections.Generic;
using System.Text;

namespace GrandPrixExam.Models
{
    public abstract class Tyre
    {
        private double degradation;

        public Tyre(double hardness)
        {
            this.Hardness = hardness;
            this.Degradation = 100;
        }

        public virtual double Degradation
        {
            get { return degradation; }
            protected set {
                if (value<0)
                {
                    throw new ArgumentException("Blown Tyre");
                }
                degradation = value; }
        }

        public abstract string Name { get; }
        public double Hardness { get;}

        public virtual void ReduceDegradation()
        {
            this.Degradation -= this.Hardness;
        }
    }
}
