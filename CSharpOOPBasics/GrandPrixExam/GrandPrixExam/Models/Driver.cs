using System;
using System.Collections.Generic;
using System.Text;

namespace GrandPrixExam.Models
{
    public abstract class Driver : IDriver
    {
        private string name;
        private double totalTime;
        private Car car;
        private double fuelConsumptionPerKm;

        public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.car.FuelAmount;

        public double FuelConsumptionPerKm
        {
            get { return fuelConsumptionPerKm; }
            protected set { fuelConsumptionPerKm = value; }
        }

        public Car Car
        {
            get { return car; }
            private set { car = value; }
        }

        public double TotalTime
        {
            get { return totalTime; }
            set { totalTime = value; }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

    }
}
