using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CarManager
{
    private readonly Dictionary<int, Car> cars;
    private readonly Dictionary<int, Race> races;
    private Garage garage;

    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower,
        int acceleration, int suspension, int durability)
    {
        var car = CarFactory.Create(type, brand, model, yearOfProduction, horsepower, acceleration, suspension,
            durability);
        cars[id] = car;
    }

    public string Check(int id)
    {
        return cars[id].ToString().Trim();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        var race = RaceFactory.Create(type, length, route, prizePool);
        races[id] = race;
    }

   
    public void Participate(int carId, int raceId)
    {
        var car = cars[carId];
        var race = races[raceId];

        if (!garage.ParkedCars.ContainsKey(carId))
        {
            race.Paritcipants[carId] = car;
        }
    }

    public string Start(int id)
    {
        var race = races[id];

        if (race.Paritcipants.Count == 0)
        {
            return $"Cannot start the race with zero participants.";
        }

        this.races.Remove(id);
        return race.ToString();
    }

    public void Park(int id)
    {
        foreach (var race in races)
        {//Participants
            if (race.Value.Paritcipants.ContainsKey(id))
            {
                return;
            }
        }
        var car = cars[id];
        garage.ParkedCars.Add(id, car);
    }

    public void Unpark(int id)
    {
        garage.ParkedCars.Remove(id);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        var parkedCars = garage.ParkedCars;

        foreach (var parkedCar in parkedCars)
        {
            var carName = parkedCar.Value.GetType().Name;
            parkedCar.Value.Horespower += tuneIndex;
            parkedCar.Value.Suspension += tuneIndex / 2;

            switch (carName)
            {
                case "ShowCar":
                    var currentCar = (ShowCar)parkedCar.Value;
                    currentCar.Stars += tuneIndex;
                    break;
                case "PerformanceCar":
                    var performanceCar = (PerformanceCar)parkedCar.Value;
                    performanceCar.AddOns.Add(addOn);
                    break;
            }
        }
    }
}