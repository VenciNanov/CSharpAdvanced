using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private Dictionary<string, Driver> drivers;
    private Dictionary<Driver, string> unfinishedDrivers;
    private int numberOfLaps;
    private int currentLap;
    private Weather weather;
    public Driver Winner { get; private set; }
    public int LenghtOfTrack { get; set; }
    public bool IsEndOfRace { get; private set; }

    public int NumberOfLaps
    {
        get => this.NumberOfLaps;
        set
        {
            if (value < 0)
            {
                throw new InvalidOperationException($"There is no time! On lap {this.currentLap}.");
            }
            this.numberOfLaps = value;
        }
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        //TODO: Add some logic here …
    }
    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            var tyreArgs = commandArgs.Skip(4).ToList();
            var carArgs = commandArgs.Skip(2).Take(2).ToList();
            var driverArgs = commandArgs.Take(2).ToList();

            var tyre = TyreFactory.Create(tyreArgs);
            var car = CarFactory.Create(carArgs, tyre);
            var driver = DriverFactory.Create(driverArgs, car);

            this.drivers.Add(driverArgs[1], driver);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        //TODO: Add some logic here …
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        var sb = new StringBuilder();
        var currentNumberOfLaps = int.Parse(commandArgs[0]);

        try
        {
            this.NumberOfLaps -= currentNumberOfLaps;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        for (int i = 0; i < currentNumberOfLaps; i++)
        {
            SetTotalTimeOfDriver();
            DoDriverContinueTheRace();
            RemoveIneligbleDriversFromDictionary();

            this.currentLap++;
            var driversToOvertake = this.drivers.Values.OrderByDescending(x => x.TotalTime).ToList();
        }
        if (this.NumberOfLaps==0)
        {
            this.IsEndOfRace = true;
            this.Winner = this.drivers.Values.OrderByDescending(x => x.TotalTime).FirstOrDefault();
        }

        return sb.ToString().Trim();
    }

    public string GetLeaderboard()
    {
        //TODO: Add some logic here …
        return string.Empty;
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        //TODO: Add some logic here …
    }

}
